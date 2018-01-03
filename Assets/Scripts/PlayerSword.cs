using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour 
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private string swingTrigger;
    
    public bool IsSwinging { get; private set; }

    private Collider2D swordCollider;

    private void Awake()
    {
        swordCollider = GetComponent<Collider2D>();
        swordCollider.enabled = false;
        IsSwinging = false;
    }

    public void SwingSword()
    {
        playerAnimator.SetTrigger(swingTrigger);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.ApplyDamage(damage);
        }
    }

    public void EnableSwordCollider(bool enable)
    {
        swordCollider.enabled = enable;
    }

    public void SetIsSwordSwinging(bool swing)
    {
        IsSwinging = swing;
    }
}
