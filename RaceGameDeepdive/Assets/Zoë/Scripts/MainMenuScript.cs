using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuScript : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject optionsFirstButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("ZoëScene");
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(optionsFirstButton);

    }
    public void QuitGame ()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
