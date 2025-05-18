using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    private Queue<Enemy> enemyQueue = new Queue<Enemy>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterEnemy(Enemy enemy)
    {
        enemyQueue.Enqueue(enemy);
        Debug.Log($"Enemy hinzugefügt. Aktuelle Anzahl: {enemyQueue.Count}");
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C) && enemyQueue.Count > 0)
        {
           
            Enemy[] enemies = enemyQueue.ToArray();

            Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
 
            randomEnemy.Highlight();
        }
    }
}
