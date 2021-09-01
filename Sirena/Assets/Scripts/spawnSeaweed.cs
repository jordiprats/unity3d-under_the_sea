using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSeaweed : MonoBehaviour {
    public GameObject[] seaweedsPrefab;
    public float respawnTime = 15.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start ()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(seaweedWave());
    }
    private void newWaveseaweeds()
    {
        foreach(GameObject seaweedPrefab in seaweedsPrefab)
        {
            GameObject a = Instantiate(seaweedPrefab) as GameObject;
            a.transform.position = new Vector3(GameObject.Find("/spawner").transform.position.x+Random.Range(0,15), a.transform.position.y, a.transform.position.z);
        }
    }
    IEnumerator seaweedWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            newWaveseaweeds();
        }
    }
}