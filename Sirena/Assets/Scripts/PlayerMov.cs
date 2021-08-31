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

	public AudioClip hit_sound;
	public AudioClip coin_sound;

	private Vector2 touchOrigin = -Vector2.one;

	void Start ()
	{
		Time.timeScale = 1;
		rb = this.GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-speed, 0);
		this.coin_sound = (AudioClip)Resources.Load("sounds/coin", typeof(AudioClip));
		this.hit_sound = (AudioClip)Resources.Load("sounds/hit", typeof(AudioClip));
	}

	// Update is called once per frame
	void Update ()
	{
		int vertical = 0;
		// int horizontal = 0;


		// check move method
		#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

		vertical = (int)Input.GetAxisRaw("Vertical");
		// horizontal = (int)Input.GetAxisRaw("Horizontal");

		#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE

		if (Input.touchCount > 0)
		{
			Touch myTouch = Input.touches[0];

			if (myTouch.phase == TouchPhase.Began)
			{
				touchOrigin = myTouch.position;
			}
			else
			{
				Vector2 touchEnd = myTouch.position;
				float x = touchEnd.x - touchOrigin.x;
				float y = touchEnd.y - touchOrigin.y;

				touchOrigin = touchEnd;

				if (Mathf.Abs(y) > 5)
					vertical = (int) (y > 0 ? ((float)Mathf.Abs(y))/10.0f : -((float)Mathf.Abs(y))/10.0f);
			}
		}

		#endif
		
		horizontalMove = speed;
		verticalMove = vertical * verticalSpeed;
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

	public void CoinSound()
	{
		this.GetComponent<AudioSource>().PlayOneShot(this.coin_sound, 1.0f);
	}

	public void HitSound()
	{
		this.GetComponent<AudioSource>().PlayOneShot(this.hit_sound, 1.0f);
	}
}
