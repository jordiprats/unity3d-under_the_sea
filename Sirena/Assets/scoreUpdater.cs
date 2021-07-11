using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreUpdater : MonoBehaviour
{

    public GameObject player;
	private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/player/xfollower");
        scoreText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
	void Update ()
    {
		scoreText.text = player.transform.position.x.ToString("0");
	}
}
