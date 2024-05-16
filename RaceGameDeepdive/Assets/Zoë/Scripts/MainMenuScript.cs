using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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
    }
}
