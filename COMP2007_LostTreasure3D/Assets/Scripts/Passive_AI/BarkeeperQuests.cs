using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class BarkeeperQuests : MonoBehaviour
{
    //Unity References
    public GameObject DialogBoxBarkeep; // GameObject for Dad NPC Dialog Box

    //Barkeep Text Boxes
    public GameObject DialogIntroduction;
    public GameObject DialogGoldenBottle;
    public GameObject DialogCleanOutside; 
    public GameObject DialogLostTreasure;


    //Quest Items
    public GameObject GoldenBottle;
    public GameObject ItemClearUp;
    public GameObject LostTreasure;


    //Barkeep SFX
    public AudioSource barkeepSFX;


    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxBarkeep.SetActive(false); //NPC Dialog Box is equal to False

        //Organise what dialog boxes will be active
        DialogIntroduction.SetActive(true);
        DialogGoldenBottle.SetActive(false);
        DialogCleanOutside.SetActive(false);
        DialogLostTreasure.SetActive(false);
        #endregion


        #region set quests objectives to false
        GoldenBottle.SetActive(false);
        ItemClearUp.SetActive(false);
        LostTreasure.SetActive(false);
        #endregion
    }


    void Update()
    {
        #region Allow Player to deactivate Dialog Box if they are active in the game
        if (DialogBoxBarkeep.activeInHierarchy && Input.GetKeyDown("q"))
        {
            DialogBoxBarkeep.SetActive(false);
        }
        #endregion

        BarkeepQuests();
    }


    public void BarkeepQuests()
    {
        //Bool to check amount of coins
        bool checkCoins = false;

        if (Coin.money == 10) // If Player picks up 10 coins, continue quest
        {
            DialogIntroduction.SetActive(false);
            DialogGoldenBottle.SetActive(true);
            GoldenBottle.SetActive(true);
            checkCoins = true;
        }
        if (checkCoins == true && GoldenBottle.activeInHierarchy == false) //If the player has 10 coins and the Golden Bottle has been collected, continue quest line
        {
            DialogGoldenBottle.SetActive(false);
            ItemClearUp.SetActive(true);
            DialogCleanOutside.SetActive(true);
        }
        if (checkCoins == true && GoldenBottle.activeInHierarchy == false && ItemClearUp.activeInHierarchy == false) //If the player has 10 coins and the Golden Bottle has been collected and the boxes have been clear, finish quest
        {
            DialogCleanOutside.SetActive(false);
            DialogLostTreasure.SetActive(true);
            LostTreasure.SetActive(true);
        }
    }


        public void OnTriggerStay(Collider collision)
    {
        #region Triggers for NPC Dialog Boxes
        if (collision.tag == "Player" && Input.GetKey("e"))
        {
            Debug.Log("Collided with Npc");
            DialogBoxBarkeep.SetActive(true); // Display NPC Dialog Box when Player Collides with NPC
            barkeepSFX.Play(0); // Play NPC SFX
        }
        #endregion
    }
}
