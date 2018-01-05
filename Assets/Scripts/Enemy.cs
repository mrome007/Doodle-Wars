using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField]
    private float health;

    [SerializeField]
    private float invulnerableFrames;
    
    public int EnemyIndex { get; set; }

    public event EventHandler<EnemyDestroyedEventArgs> EnemyDestroyed;

    private EnemyMovement enemyMovement;
    private Collider2D enemyCollider;
    private Animator enemyAnimator;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyCollider = GetComponent<Collider2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        var handler = EnemyDestroyed;
        if(handler != null)
        {
            handler(this, new EnemyDestroyedEventArgs(EnemyIndex));
        }
    }

    public void ApplyDamage(float damage)
    {
        StartCoroutine(DisplayTakingDamage());
        health -= damage;

        if(health <= 0f)
        {
            EnemyDeath();
        }
    }

    private IEnumerator DisplayTakingDamage()
    {
        enemyMovement.Move = false;
        enemyCollider.enabled = false;
        enemyAnimator.SetTrigger("Hit");

        yield return new WaitForSeconds(2f);
        enemyMovement.Move = true;
        enemyCollider.enabled = true;
    }

    private void EnemyDeath()
    {
        enemyMovement.Move = false;
        enemyCollider.enabled = false;
        Destroy(gameObject, 1f);
    }

    public void EnemyMove(float delay)
    {
        enemyMovement.DelayMove(delay);
    }
}
