using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour 
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform leftWorldConstraint;

    [SerializeField]
    private Transform rightWorldConstraint;

    [SerializeField]
    private float speed;

    private Vector3 initialCamPos;
    private Vector3 targetVector;
    private float constraintOffset = 6f;
    private float minX;
    private float maxX;

    private void Awake()
    {
        initialCamPos = transform.position;
        targetVector = initialCamPos;
    }

    private void Update()
    {
        targetVector.x = playerTransform.position.x;
        ClampFollow();
        transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);
    }

    private void ClampFollow()
    {
        var realConstraintOffset = (rightWorldConstraint.position.x - leftWorldConstraint.position.x) / 2f;
        var offset = realConstraintOffset < constraintOffset ? realConstraintOffset : constraintOffset;

        minX = leftWorldConstraint.position.x + offset;
        maxX = rightWorldConstraint.position.x - offset;

        targetVector.x = Mathf.Clamp(targetVector.x, minX, maxX);
    }
}
