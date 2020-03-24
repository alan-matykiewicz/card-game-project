using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject mainMenuPrefab;
    public GameObject joinLobbyMenuPrefab;

    private void Start()
    {
        joinLobbyMenuPrefab.SetActive(false);
    }

    public void GoToLobbyMenu()
    {
        mainMenuPrefab.SetActive(false);
        joinLobbyMenuPrefab.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
