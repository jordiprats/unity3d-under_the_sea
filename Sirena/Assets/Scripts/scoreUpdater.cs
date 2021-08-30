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
        if (player.transform.position.x > 0)
        {
            scoreText.text = "Distància: " + player.transform.position.x.ToString("0");
        }
        else scoreText.text = "Distància: 0";
		
	}
}
