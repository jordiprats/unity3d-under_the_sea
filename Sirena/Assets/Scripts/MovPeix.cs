using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPeix : MonoBehaviour {
    public float speed = 2.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update ()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

        if(transform.position.x+40 < GameObject.Find("/peix_spawner").transform.position.x )
        {
            Destroy(this.gameObject);
        }
    }
}