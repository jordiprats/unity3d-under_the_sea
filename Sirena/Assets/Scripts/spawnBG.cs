using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBG : MonoBehaviour {
    public GameObject[] bgsPrefab;
    public float respawnTime = 15.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start ()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(bgWave());
    }
    private void newWavebgs()
    {
        foreach(GameObject bgPrefab in bgsPrefab)
        {
            GameObject a = Instantiate(bgPrefab) as GameObject;
            a.transform.position = new Vector3(GameObject.Find("/spawner").transform.position.x+Random.Range(0,15), a.transform.position.y, a.transform.position.z);
        }
    }
    IEnumerator bgWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            newWavebgs();
        }
    }
}