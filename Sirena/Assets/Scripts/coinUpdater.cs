using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinUpdater : MonoBehaviour
{
	private TextMeshProUGUI scoreText;

    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
	void Update ()
    {
        scoreText.text = "Monedes: " + coins.ToString("0");
	}
}
