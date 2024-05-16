using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MainMenuScript : MonoBehaviour
{
    [Header("MenuObject")]
    [SerializeField] private GameObject _startGameMenu;
    [SerializeField] private GameObject _mapSelectMenu;

    [Header("FirstSelectedButtons")]
    [SerializeField] private GameObject _startMenuFirst;
    [SerializeField] private GameObject _mapMenuFirst;

    private void Start()
    {
        _startGameMenu.SetActive(true);
        _mapSelectMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_startMenuFirst);
    }

    private void OpenMapSelectMenu()
    {
        _startGameMenu.SetActive(false);
        _mapSelectMenu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_mapMenuFirst);
    }

    private void OpenStartGameMenu()
    {
        _startGameMenu.SetActive(true);
        _mapSelectMenu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_startMenuFirst);
    }

    #region Button Presses
    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void OnMapSelectPress()
    {
        OpenMapSelectMenu();
    }

    public void OnBackPress()
    {
        OpenStartGameMenu();
    }

    public void OnLapModePress()
    {
        SceneManager.LoadScene("ZoëScene");
    }

    public void OnGhostModePress()
    {
        SceneManager.LoadScene("HaydenScene");
    }
    #endregion
}
