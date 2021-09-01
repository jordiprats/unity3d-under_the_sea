using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	bool isPaused;

	// Use this for initialization
	void Start ()
	{
		isPaused = false;

		setPauseStatus();
	}

	void setPauseStatus()
	{
		this.GetComponent<Canvas>().enabled = isPaused;
		GameObject.Find("/spawner").GetComponent<AudioSource>().mute = isPaused;

		if (isPaused)
			Time.timeScale = 0;
		
		if (!isPaused)
			Time.timeScale = 1;
	}

	public void ToggleGamePause()
	{
		isPaused = !isPaused;
		setPauseStatus();
	}

	void OnApplicationPause()
	{
		isPaused = true;
		setPauseStatus();
	}

	void OnApplicationFocus(bool hasFocus)
	{
		if (!hasFocus)
		{
			isPaused = true;
			setPauseStatus();
		}
	}

	public void Sortir()
	{
			Application.Quit();
	}

	public void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = true;
			setPauseStatus();
		}
	}
}
