using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    //Integers
    public static int money = 0; // Integer for Players Score

    //Unity References
    public AudioSource CoinPickup; // Audio Clip for Coins

    private void Start()
    {
        money = 0; // Players Score is equal to 0 when you start the game
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player")) //If "Player" collides with coin add 1 point and destroy object
        {
            CoinPickup.Play(0); // Play audio in Coins position
            money++; // Every coin pickup equals to 1 point
            Destroy(gameObject, 0.1f); // Destroy Coin gameObject when Player collides

            Debug.Log("Player Has Collided!"); // Display Debug Log in Console
        }
    }
}
