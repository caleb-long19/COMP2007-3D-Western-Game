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

    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Loads a scene called "OrionFlower"
    }

    public void Exit()
    {
        Application.Quit(); // Quits the application
    }
}
