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

    public enum EnemyType
    {
        Blob = 0,
        Slug = 1,
        Hairy = 2,
        Fabulous = 3,
        Demon = 4,
        Wandering = 5,
        NoType = 6,
    }

    [SerializeField]
    private List<Enemy> enemyObjects;

    [SerializeField]
    private Enemy bossObject;

    private float spawnPosOffset = 10f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = (EnemySpawner)FindObjectOfType(typeof(EnemySpawner));
        }
    }

    public List<Enemy> SpawnRandomEnemies(int numberOfEnemies, float minXPos, float maxXPos)
    {
        var enemies = new List<Enemy>();

        for(int index = 0; index < numberOfEnemies; index++)
        {
            var left = Random.Range(0, 2) == 0;
            var pos = new Vector3(left ? minXPos - spawnPosOffset : maxXPos + spawnPosOffset, 0f, 0f);
            var enemy = Instantiate(enemyObjects[Random.Range(0, enemyObjects.Count)], pos, Quaternion.identity);
            enemy.EnemyIndex = index;
            enemy.EnemyMove(index + Random.Range(0f, 2f));
            enemies.Add(enemy);
        }
        return enemies;
    }

    public List<Enemy> SpawnRandomEnemies(int numberOfEnemies, bool left, float position)
    {
        var enemies = new List<Enemy>();

        for(int index = 0; index < numberOfEnemies; index++)
        {
            var pos = new Vector3(left ? position - spawnPosOffset : position + spawnPosOffset, 0f, 0f);
            var enemy = Instantiate(enemyObjects[Random.Range(0, enemyObjects.Count)], pos, Quaternion.identity);
            enemy.EnemyIndex = index;
            enemy.EnemyMove(index + Random.Range(0f, 2f));
            enemies.Add(enemy);
        }
        return enemies;
    }

    public List<Enemy> SpawnSpecificEnemies(EnemyType enemyType, int numberOfEnemies, float minXPos, float maxXPos)
    {
        var enemyNumType = (int)enemyType;
        if(enemyNumType >= enemyObjects.Count)
        {
            enemyNumType = Random.Range(0, enemyObjects.Count);
        }
        
        var enemies = new List<Enemy>();

        for(int index = 0; index < numberOfEnemies; index++)
        {
            var left = Random.Range(0, 2) == 0;
            var pos = new Vector3(left ? minXPos - spawnPosOffset : maxXPos + spawnPosOffset, 0f, 0f);
            var enemy = Instantiate(enemyObjects[enemyNumType], pos, Quaternion.identity);
            enemy.EnemyIndex = index;
            enemy.EnemyMove(index + Random.Range(0f, 2f));
            enemies.Add(enemy);
        }
        return enemies;
    }

    public List<Enemy> SpawnSpecificEnemies(EnemyType enemyType, int numberOfEnemies, bool left, float position)
    {
        var enemyNumType = (int)enemyType;
        if(enemyNumType >= enemyObjects.Count)
        {
            enemyNumType = Random.Range(0, enemyObjects.Count);
        }

        var enemies = new List<Enemy>();

        for(int index = 0; index < numberOfEnemies; index++)
        {
            var pos = new Vector3(left ? position - spawnPosOffset : position + spawnPosOffset, 0f, 0f);
            var enemy = Instantiate(enemyObjects[enemyNumType], pos, Quaternion.identity);
            enemy.EnemyIndex = index;
            enemy.EnemyMove(index + Random.Range(0f, 2f));
            enemies.Add(enemy);
        }
        return enemies;
    }

    public List<Enemy> SpawnBoss(float position)
    {
        var enemies = new List<Enemy>();
        var enemy = Instantiate(bossObject, new Vector3(position, 0f, 0f), Quaternion.identity);
        enemy.EnemyIndex = 0;
        enemy.EnemyMove(0f);
        enemies.Add(enemy);
        return enemies;
    }
}
