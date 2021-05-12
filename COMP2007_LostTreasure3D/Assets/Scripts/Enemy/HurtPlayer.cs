using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damage; // Integer value for amount of Damage Enemy Deals
    public float resetTime = 0.25f; // Reset time for enemies collider when they attack the Player

    private void OnTriggerEnter(Collider collision)
    {
        collision.transform.SendMessage("TakeEnemyDamage", damage, SendMessageOptions.DontRequireReceiver);  // When Enemy collides with Player, Player takes damage
        GetComponent<Collider>().enabled = false; // Enemy collider is equal to false
        Invoke("ResetCollision", resetTime); // Reset Enemy collider after specific time interval
    }

    private void ResetCollision()
    {
        GetComponent<Collider>().enabled = true; // Resets Enemy collision
    }
}
