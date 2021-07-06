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
		controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
		GameObject.Find("/player/xfollower").transform.position=new Vector3(GameObject.Find("/player").transform.position.x, 0, GameObject.Find("/player").transform.position.z);

		Vector3 pos = transform.position;
		pos.y =  Mathf.Clamp(transform.position.y, -4.4f , 3.9f);
     	transform.position = pos;
	}
}
