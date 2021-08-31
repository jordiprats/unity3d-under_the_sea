using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private GameObject LoseCoin(int coin_value)
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 2f;

        GameObject coin = (GameObject)Resources.Load("prefabs/monedes/moneda_"+coin_value.ToString(), typeof(GameObject));

        GameObject loose_coin = Instantiate(coin, position, this.transform.rotation);

        loose_coin.GetComponent<Rigidbody2D>().velocity = new Vector2( (Random.Range(0,2)*2-1)*Random.Range(5,15), Random.Range(5,15));
        loose_coin.GetComponent<Rigidbody2D>().gravityScale = 2;
        loose_coin.GetComponent<Rigidbody2D>().mass = 5;
        loose_coin.GetComponent<Collider2D>().enabled = false;

        return loose_coin;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            

            collision.gameObject.GetComponent<PlayerMov>().HitSound();

            GameObject cointracker = GameObject.Find("/ui/coins");

            if (cointracker.GetComponent<coinUpdater>().coins<30)
            {
                cointracker.GetComponent<coinUpdater>().coins -= 3;

                LoseCoin(1);
                LoseCoin(1);
                LoseCoin(1);
            }
            else if (cointracker.GetComponent<coinUpdater>().coins<60)
            {
                cointracker.GetComponent<coinUpdater>().coins -= 9;

                LoseCoin(3);
                LoseCoin(2);
                LoseCoin(1);
                LoseCoin(1);
                LoseCoin(1);
                LoseCoin(1);
            }
            else if (cointracker.GetComponent<coinUpdater>().coins<160)
            {
                cointracker.GetComponent<coinUpdater>().coins -= 30;

                LoseCoin(10);
                LoseCoin(10);
                LoseCoin(4);
                LoseCoin(3);
                LoseCoin(1);
                LoseCoin(2);
            }
            else
            {
                cointracker.GetComponent<coinUpdater>().coins -= 60;

                LoseCoin(10);
                LoseCoin(10);
                LoseCoin(10);
                LoseCoin(10);
                LoseCoin(10);
                LoseCoin(4);                
                LoseCoin(1);                
                LoseCoin(1);                
                LoseCoin(1);                
                LoseCoin(1);                
                LoseCoin(1);                
                LoseCoin(1);                
            }

            if (cointracker.GetComponent<coinUpdater>().coins<0)
            {
                Time.timeScale = 0;
                cointracker.GetComponent<coinUpdater>().coins = 0;
                GameObject.Find("/peix_spawner").GetComponent<AudioSource>().mute = true;
                GameObject.Find("/player").GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("sounds/death", typeof(AudioClip)));

                StartCoroutine(WaitForSceneLoad());
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }

    IEnumerator WaitForRealSeconds (float seconds)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup-startTime < seconds)
        {
            yield return null;
        }
    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return StartCoroutine(WaitForRealSeconds(5.0f));
        SceneManager.LoadScene("Menu");
    }


}