using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public MovCon controller;

	public float runSpeed = 10f;
	public float verticalSpeed = 40f;

	public float speed = 30.0f;

	float horizontalMove = 0f;
	float verticalMove = 0f;

	private Rigidbody2D rb;

    void Start ()
	{
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

	// Update is called once per frame
	void Update ()
	{
		horizontalMove = (Input.GetAxisRaw("Horizontal") * runSpeed) + speed;
		verticalMove = Input.GetAxisRaw("Vertical") * verticalSpeed;	
	}

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
		GameObject.Find("/player/xfollower").transform.position=new Vector3(GameObject.Find("/player").transform.position.x, 0, GameObject.Find("/player").transform.position.z);

		GameObject.Find("/peix_spawner").transform.position=new Vector3(GameObject.Find("/player").transform.position.x+15, 0, GameObject.Find("/player").transform.position.z);

		Vector3 pos = transform.position;
		pos.y =  Mathf.Clamp(transform.position.y, -4.4f , 3.9f);
     	transform.position = pos;
	}
}
