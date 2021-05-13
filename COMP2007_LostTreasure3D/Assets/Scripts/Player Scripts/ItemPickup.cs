using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    //Unity References
    public AudioSource ItemPickupSFX; // Audio Clip for Items

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Pickup") && Input.GetKey("e")) //If "Player" collides with Item, setactive to false 
        {
            ItemPickupSFX.Play(0); // Play item pickup SFX
            GameObject HideObject = collision.gameObject; // hide game object
            HideObject.SetActive(false);

            Debug.Log("Player Has Collected Item!"); // Display Debug Log in Console
        }
    }
}
