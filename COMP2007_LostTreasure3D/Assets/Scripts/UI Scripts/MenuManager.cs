using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1; // Unpauses the game
    }


    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Loads a scene called "GameScene"
    }


    public void Exit()
    {
        Application.Quit(); // Quits the application
    }
}
