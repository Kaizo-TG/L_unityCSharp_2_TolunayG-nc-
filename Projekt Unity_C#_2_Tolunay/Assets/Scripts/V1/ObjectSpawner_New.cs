using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner_New : MonoBehaviour
{
    [Header("Pooling Einstellungen")]
    public int initialPoolSize = 10;
    private List<GameObject> enemyPool = new List<GameObject>();

    [Header("Spawn Einstellungen")]
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10);
    public Vector3 spawnAreaMax = new Vector3(10, 0, 10);

    private GameObject enemyPrefab;

    void Start()
    {
        // Prefab aus Resources laden
        enemyPrefab = Resources.Load<GameObject>("Enemy");

        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab konnte nicht aus Resources geladen werden!");
            return;
        }

        // Pool füllen
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    void Update()
    {
        // Leertaste → aktiviere Enemy aus Pool
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFromPool();
        }

        // Taste C → alle aktiven Enemys einfärben
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (GameObject enemy in enemyPool)
            {
                if (enemy.activeInHierarchy)
                {
                    Enemy script = enemy.GetComponent<Enemy>();
                    if (script != null)
                        script.ColorChange();
                }
            }
        }
    }

    void SpawnFromPool()
    {
        GameObject enemyToSpawn = null;

        // Suche inaktiviertes Objekt im Pool
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemyToSpawn = enemy;
                break;
            }
        }

        // Wenn keins frei: neues instanziieren & zum Pool hinzufügen
        if (enemyToSpawn == null)
        {
            enemyToSpawn = Instantiate(enemyPrefab);
            enemyPool.Add(enemyToSpawn);
        }

        // Zufällige Position festlegen
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(x, spawnAreaMin.y, z);

        // Enemy aktivieren & positionieren
        enemyToSpawn.transform.position = spawnPosition;
        enemyToSpawn.SetActive(true);
    }
}
