using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuObject : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("EndlessSwimmer");
    }    

    public void Sortir()
    {
        Application.Quit();
    }
}
