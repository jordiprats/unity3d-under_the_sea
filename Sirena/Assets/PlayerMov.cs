using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public MovCon controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	float verticalMove = 0f;

	
	// Update is called once per frame
	void Update ()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
	}
}
