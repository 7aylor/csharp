using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : MonoBehaviour {

    public GameObject[] enemy_types;

    static int enemyCount = 0;
    int childCount;

    private void Start()
    {
        childCount = gameObject.transform.childCount;
    }

    //spawns all enemies in child positions
    public void SpawnEnemies()
    {
        foreach(Transform child in gameObject.transform)
        {
            SpawnEnemy(child);
        }
        Debug.Log("Start enemy count: " + enemyCount);
    }

    //spawns one enemy in a given position
    void SpawnEnemy(Transform spawnPosition)
    {
        int index = Random.Range(0, enemy_types.Length);
        GameObject enemy = Instantiate(enemy_types[index], spawnPosition.position, Quaternion.identity);
        enemy.transform.parent = spawnPosition;
        increaseEnemyCountByOne();
        Debug.Log("Enemy Spawned");
        
    }

    public void decreaseEnemyCountByOne()
    {
        enemyCount--;
    }

    public void increaseEnemyCountByOne()
    {
        enemyCount++;
    }

    public int getEnemyCount()
    {
        return enemyCount;
    }

    public void destroyAllEnemies()
    {
        foreach(Transform enemy in gameObject.transform)
        {
            Destroy(enemy.gameObject);
        }
    } 

}
