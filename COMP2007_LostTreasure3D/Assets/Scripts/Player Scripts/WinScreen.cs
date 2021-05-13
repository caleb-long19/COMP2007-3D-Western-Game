using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject Win; // Attatch gameObject called DeathMenu in unity
    public GameObject Player; // Player GameObject
    public AudioSource winSFX;

    private void Start()
    {
        Win.SetActive(false); // When the Game Starts, Win Screen is inactive
    }


    private void OnTriggerStay(Collider collision)
    {
        // If Player presses Space on the House and has acquired the treasure, run if statement
        if (Input.GetKey("e") & collision.tag.Equals("Player"))
        {
            Win.SetActive(true); // When Player collides with Main House and has the treasure, Win Screen is Active
            Player.SetActive(false); // Player is set to Inactive      
            Time.timeScale = 0; // Game is paused
            winSFX.Play(0);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // When Restart Button is Selected, Reload Current Scene
        Time.timeScale = 1; // Game is unpaused
    }


    public void Exit()
    {
        SceneManager.LoadScene("MainMenu"); // When Exit Button is pressed, Exit to Main Menu Sceen
        Debug.Log("You have quit the game!");
    }
}
