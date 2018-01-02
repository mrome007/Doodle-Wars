using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour 
{
    [SerializeField]
    private float swingSpeed;

    [SerializeField]
    private float damage;
    
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
        StartCoroutine(SwingSwordRoutine());
    }

    private IEnumerator SwingSwordRoutine()
    {
        IsSwinging = true;
        swordCollider.enabled = true;

        while(transform.localRotation.eulerAngles.z < 100f)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * swingSpeed);
            yield return null;
        }

        swordCollider.enabled = false;

        while(transform.localRotation.eulerAngles.z > 30f)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * swingSpeed);
            yield return null;
        }

        IsSwinging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.ApplyDamage(damage);
        }
    }
}
