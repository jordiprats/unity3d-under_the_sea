using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuObject : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("/Canvas/titol").GetComponent<TextMeshProUGUI>().text = "Sílvia's mermaids";
    }
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
