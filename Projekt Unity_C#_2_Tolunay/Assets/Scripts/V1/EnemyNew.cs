using System.Collections.Generic;
using UnityEngine;

public class Enemy_new : MonoBehaviour
{
    // Statische Queue für alle Enemys
    private static Queue<Enemy_new> enemyQueue = new Queue<Enemy_new>();

    void Start()
    {
        // Registriert sich selbst in der statischen Liste
        enemyQueue.Enqueue(this);
        Debug.Log($"Enemy hinzugefügt. Aktuelle Anzahl: {enemyQueue.Count}");
    }

    void Update()
    {
        // Nur EIN Enemy soll reagieren (optional)
        // Prüfen ob dieser das erste Objekt in der Szene ist (z.B. als Leader)
        if (Input.GetKeyDown(KeyCode.C) && enemyQueue.Count > 0)
        {
            Enemy_new[] enemies = enemyQueue.ToArray();
            Enemy_new randomEnemy = enemies[Random.Range(0, enemies.Length)];
            randomEnemy.Highlight();
        }
    }

    public void Highlight()
    {
        // Beispielhafte Reaktion: Rot färben
        GetComponent<Renderer>().material.color = Color.red;
    }
}
