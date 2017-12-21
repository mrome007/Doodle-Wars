using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	private void Update()
	{
		var h = Input.GetAxis("Horizontal");
		var v = Input.GetAxis("Vertical");

		transform.Translate(new Vector2(h, v) * Time.deltaTime * 10f);
	}
}
