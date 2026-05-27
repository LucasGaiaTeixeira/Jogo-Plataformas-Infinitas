using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyGround : MonoBehaviour
{
    public List<GameObject> enemy = new List<GameObject>();
    public List<Transform> spawnPoints = new List<Transform>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            int indexSpawn = Random.Range(0, spawnPoints.Count);
            int indexEnemy = Random.Range(0, enemy.Count);
            Instantiate(enemy[indexEnemy], spawnPoints[indexSpawn].position, transform.rotation);
            spawnPoints.RemoveAt(indexSpawn);
        }
    }

    
}
