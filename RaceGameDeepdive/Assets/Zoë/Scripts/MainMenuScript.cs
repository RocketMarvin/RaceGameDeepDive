using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Zo�Scene");
    }

    public void QuitGame ()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
