using System.Collections.Generic;
using UnityEngine;

public class SpanwEnemis : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    
    

    

    private float spawnEnemiesTime;
    public int spawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnEnemiesTime += Time.deltaTime;
        
        if (spawnEnemiesTime >= spawnTime)
        {
            
            spawnEnemiesFly();
            spawnEnemiesTime = 0f;
        }
    }

    public void spawnEnemiesFly()
    {
        int randomEnemys = Random.Range(0, enemies.Count);
        Instantiate(enemies[randomEnemys], new Vector3(transform.position.x,Random.Range(1.98f, 7.3f),0), transform.rotation);
    }
}
