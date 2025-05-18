using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Drag & Drop in Inspector
    public Vector3 spawnAreaMin = new Vector3(-10, 0, -10);
    public Vector3 spawnAreaMax = new Vector3(10, 0, 10);

    private List<Enemy> spawnedEnemies = new List<Enemy>();

    void Update()
    {
        // Leertaste: Enemy instanziieren
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }

        // Taste C: Farbe aller Enemys ändern
        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (Enemy enemy in spawnedEnemies)
            {
                if (enemy != null)
                    enemy.ColorChange();
            }
        }
    }

    void SpawnEnemy()
    {
        // Zufällige Position berechnen
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
        Vector3 spawnPosition = new Vector3(x, spawnAreaMin.y, z);

        // Enemy instanziieren
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Enemy zur Liste hinzufügen
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            spawnedEnemies.Add(enemyScript);
        }
    }
}
