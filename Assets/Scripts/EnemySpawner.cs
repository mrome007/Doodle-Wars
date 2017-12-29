using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    #region Instance

    public static EnemySpawner Instance
    {
        get
        {
            if(instance == null)
            {
                instance = (EnemySpawner)FindObjectOfType(typeof(EnemySpawner));
            }
            return instance;
        }
        
    }

    private static EnemySpawner instance = null;

    #endregion

    [SerializeField]
    private List<Enemy> enemyObjects;

    private void Awake()
    {
        if(instance == null)
        {
            instance = (EnemySpawner)FindObjectOfType(typeof(EnemySpawner));
        }
    }

    public List<Enemy> SpawnEnemies(int numberOfEnemies, float minXPos, float maxXPos)
    {
        var enemies = new List<Enemy>();

        for(int index = 0; index < numberOfEnemies; index++)
        {
            var pos = new Vector3(Random.Range(minXPos, maxXPos), 0f, 0f);
            var enemy = Instantiate(enemyObjects[Random.Range(0, enemyObjects.Count)], pos, Quaternion.identity);
            enemy.EnemyIndex = index;
            enemies.Add(enemy);
        }
        return enemies;
    }
}
