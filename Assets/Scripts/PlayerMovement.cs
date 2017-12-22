using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField]
    private Transform leftConstraint;

    [SerializeField]
    private Transform rightConstraint;

    private Vector2 movementVector;
    private Vector2 clampedPosition;
    private float minX;
    private float minY;
    private float maxX;
    private float maxY;

    private void Awake()
    {
        movementVector = Vector2.zero;
        clampedPosition = Vector2.zero;
    }

	private void Update()
	{
        var h = Input.GetAxis("Horizontal");
        movementVector.x = h;
        transform.Translate(movementVector * Time.deltaTime * 10f);
        ClampMovement();
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
}
