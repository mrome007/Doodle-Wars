using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSword : MonoBehaviour 
{
    [SerializeField]
    private float swingSpeed;
    
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

        while(transform.localRotation.eulerAngles.z > 30f)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * swingSpeed);
            yield return null;
        }

        IsSwinging = false;
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
