using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour 
{
    [SerializeField]
    private float speed;

    private SpriteRenderer enemyRenderer;
    private float offset;
    private float negOffset;
    private void Awake()
    {
        enemyRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        offset = Random.Range(0.1f, 0.3f);
        negOffset *= -1f;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var playerDir = PlayerInfo.Instance.transform.position.x - transform.position.x;
        var movementDirection = Vector2.zero;

        if(playerDir < negOffset)
        {
            movementDirection.x = -1f;
            enemyRenderer.flipX = true;
        }
        else if(playerDir > offset)
        {
            movementDirection.x = 1f;
            enemyRenderer.flipX = false;
        }

        transform.Translate(movementDirection * speed * Time.deltaTime);
    }
}
