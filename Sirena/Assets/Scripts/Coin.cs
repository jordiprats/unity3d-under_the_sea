using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();

        if((transform.position.x+40 < GameObject.Find("/").transform.position.x ) || (transform.position.y < -30))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);

        if (collision.gameObject.tag == "player")
        {
            GameObject cointracker = GameObject.Find("/ui/coins");
            int coin_value = int.Parse(this.tag);

            cointracker.GetComponent<coinUpdater>().coins += coin_value;
            this.GetComponent<AudioSource>().Play();

            collision.gameObject.GetComponent<PlayerMov>().CoinSound();
        }

        
    }
}
