using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnItems : MonoBehaviour {
    public GameObject[] itemsPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start ()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(itemWave());
    }
    private void newWaveitems()
    {
        foreach(GameObject itemPrefab in itemsPrefab)
        {
            GameObject a = Instantiate(itemPrefab) as GameObject;
            a.transform.position = new Vector2(GameObject.Find("/spawner").transform.position.x+Random.Range(0,15), Random.Range(-screenBounds.y, screenBounds.y));
        }
    }
    IEnumerator itemWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            newWaveitems();
        }
    }
}