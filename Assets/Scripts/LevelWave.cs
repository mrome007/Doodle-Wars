using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWave : MonoBehaviour 
{
    [SerializeField]
    private bool bossRound;

    [SerializeField]
    private bool randomEnemies;

    [SerializeField]
    private bool hasDirection;

    [SerializeField]
    private bool left;

    [SerializeField]
    private Transform leftConstraint;

    [SerializeField]
    private Transform rightConstraint;

    [SerializeField]
    private EnemySpawner.EnemyType enemyType;

    [SerializeField]
    private int numberOfEnemies;

    public event EventHandler WaveBegin;

    public event EventHandler WaveEnd;

    private List<Enemy> enemyList;

    private int currentNumberOfEnemies;

    public Transform RightBorder
    {
        get
        {
            return rightConstraint;
        }
    }

    public Transform LeftBorder
    {
        get
        {
            return leftConstraint;
        }
    }

    private void Awake()
    {
        enemyList = new List<Enemy>();
        currentNumberOfEnemies = 0;
    }

    public void StartWave()
    {
        var handler = WaveBegin;
        if(handler != null)
        {
            handler(this, null);
        }

        if(bossRound)
        {
            //enemyList = EnemySpawner.Instance.SpawnBoss(rightConstraint.position.x);
        }
        else
        {
            if(randomEnemies)
            {
                if(hasDirection)
                {
                    enemyList = EnemySpawner.Instance.SpawnRandomEnemies(numberOfEnemies, left, left ? leftConstraint.position.x : rightConstraint.position.x);
                }
                else
                {
                    enemyList = EnemySpawner.Instance.SpawnRandomEnemies(numberOfEnemies, leftConstraint.position.x, rightConstraint.position.x);
                }
            }
            else
            {
                if(hasDirection)
                {
                    enemyList = EnemySpawner.Instance.SpawnSpecificEnemies(enemyType, numberOfEnemies, left, left ? leftConstraint.position.x : rightConstraint.position.x);
                }
                else
                {
                    enemyList = EnemySpawner.Instance.SpawnSpecificEnemies(enemyType, numberOfEnemies, leftConstraint.position.x, rightConstraint.position.x);
                }
            }
        }

        currentNumberOfEnemies = enemyList.Count;
        for(int index = 0; index < enemyList.Count; index++)
        {
            enemyList[index].EnemyDestroyed += HandleEnemyDestroyed;
        }
    }

    private void EndWave()
    {
        enemyList.Clear();

        var handler = WaveEnd;
        if(handler != null)
        {
            handler(this, null);
        }
    }

    private void HandleEnemyDestroyed(object sender, EnemyDestroyedEventArgs e)
    {
        enemyList[e.EnemyIndex].EnemyDestroyed -= HandleEnemyDestroyed;
        currentNumberOfEnemies--;

        if(currentNumberOfEnemies <= 0)
        {
            EndWave();
        }
    }

    private void OnDestroy()
    {
        for(int index = 0; index < enemyList.Count; index++)
        {
            enemyList[index].EnemyDestroyed -= HandleEnemyDestroyed;
        }
    }
}
