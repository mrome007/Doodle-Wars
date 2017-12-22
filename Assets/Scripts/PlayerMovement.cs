using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private Transform leftConstraint;

    [SerializeField]
    private Transform rightConstraint;

    [SerializeField]
    private Transform playerTransform;

    private Vector2 movementVector;
    private Vector2 clampedPosition;
    private Vector3 rotationVector;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;

    private void Awake()
    {
        movementVector = Vector2.zero;
        clampedPosition = Vector2.zero;
        rotationVector = Vector3.zero;
    }

	private void Update()
	{
        var h = Input.GetAxis("Horizontal");
        movementVector.x = h;
        transform.Translate(movementVector * Time.deltaTime * 10f);
        ClampMovement();
        RotatePlayer(h);
    }

    private void ClampMovement()
    {
        minX = leftConstraint.position.x;
        maxX = rightConstraint.position.x;
        minY = leftConstraint.position.y;
        maxY = rightConstraint.position.y;

        var x = Mathf.Clamp(transform.position.x, minX, maxX);
        var y = Mathf.Clamp(transform.position.y, minY, maxY);

        clampedPosition.x = x;
        clampedPosition.y = y;

        transform.position = clampedPosition;
    }

    private void RotatePlayer(float horizontal)
    {
        if(horizontal != 0)
        {
            rotationVector.y = horizontal > 0f ? 180f : 0f;
            playerTransform.localRotation = Quaternion.Euler(rotationVector);
        }
    }
}
