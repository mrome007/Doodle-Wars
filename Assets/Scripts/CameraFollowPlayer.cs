using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour 
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float speed;

    private Vector3 initialCamPos;
    private Vector3 targetVector;
    private void Awake()
    {
        initialCamPos = transform.position;
        targetVector = initialCamPos;
    }

    private void Update()
    {
        targetVector.x = playerTransform.position.x;
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
    }
}
