using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OctoBubbleBoss : MonoBehaviour
{
    [SerializeField]
    private List<Collider2D> colliders;
    [SerializeField]
    private Transform headTransform;
    [SerializeField]
    private Transform tentacleTransform;


    private float health = 2000f;
    private Animator bossAnimator;
    private bool moving = false;
    private Vector3 movementVector;
    private float offset;
    private float negOffset;

    private void Awake()
    {
        bossAnimator = GetComponent<Animator>();
        movementVector = Vector3.zero;

        offset = Random.Range(0.1f, 0.3f);
        negOffset = offset * -1f;
    }

    private void Start()
    {
        movementVector.y = 1f;
        GoMove();
        InvokeRepeating("StopMove", 6f, 6f);
        InvokeRepeating("UpDown", 2f, 2f);
    }

    private void Update()
    {
        if(!moving)
        {
            return;
        }

        var playerDir = PlayerInfo.Instance.transform.position.x - transform.position.x;
        var movementDirection = 0f;

        if(playerDir < negOffset)
        {
            movementDirection = -1f;
            headTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            tentacleTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if(playerDir > offset)
        {
            movementDirection = 1f;
            headTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            tentacleTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        movementVector.x = movementDirection;
        transform.Translate(movementVector * 3.25f * Time.deltaTime);

        var position = transform.position;
        if(position.y >= 4f)
        {
            position.y = 4f;
        }

        if(position.y <= -2f)
        {
            position.y = -2f;
        }

        transform.position = position;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Light")
        {
            health -= 10f;
            bossAnimator.SetTrigger("Hit");
        }

        if(other.tag == "Heavy")
        {
            health -= 100f;
            bossAnimator.SetTrigger("Hit");
        }

        if(health <= 0)
        {
            Destroy(gameObject, 1f);
        }
    }

    public void EnableColliders(int enable)
    {
        for(int index = 0; index < colliders.Count; index++)
        {
            colliders[index].enabled = enable == 1;
        }
    }

    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }

    public void StopMove()
    {
        moving = false;
        Invoke("GoMove", 1f);
    }

    public void GoMove()
    {
        moving = true;
    }

    public void UpDown()
    {
        movementVector.y *= -1f;
    }

    public void DecreaseHealth(float damage)
    {
        health -= damage;
    }
}
