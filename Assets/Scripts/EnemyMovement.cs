using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
    public bool Move { get; set; }

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform enemyContainerTransform;

    private float offset;
    private float negOffset;
    private float delayMovement;

    private void Awake()
    {
        offset = Random.Range(0.1f, 0.3f);
        negOffset = offset * -1f;
        Move = false;
    }

    private void Update()
    {
        if(!Move)
        {
            return;
        }
       
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        var playerDir = PlayerInfo.Instance.transform.position.x - transform.position.x;
        var movementDirection = Vector2.zero;

        if(playerDir < negOffset)
        {
            movementDirection.x = -1f;
            enemyContainerTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(playerDir > offset)
        {
            movementDirection.x = 1f;
            enemyContainerTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    public void DelayMove(float delay)
    {
        Invoke("GoEnemy", delay);
    }

    private void GoEnemy()
    {
        Move = true;
    }
}
