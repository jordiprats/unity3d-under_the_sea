using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPeixos : MonoBehaviour {
    public GameObject[] peixosPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start ()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void newWavePeixos()
    {
        foreach(GameObject peixPrefab in peixosPrefab)
        {
            GameObject a = Instantiate(peixPrefab) as GameObject;
            a.transform.position = new Vector2(GameObject.Find("/peix_spawner").transform.position.x+Random.Range(0,15), Random.Range(-screenBounds.y, screenBounds.y));

            MovPeix mp = a.GetComponent<MovPeix>();

            mp.speed = Random.Range(2,10);
        }
    }
    IEnumerator asteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            newWavePeixos();
        }
    }
}