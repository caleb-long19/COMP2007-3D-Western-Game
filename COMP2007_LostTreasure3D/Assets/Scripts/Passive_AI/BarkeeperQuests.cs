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
    public GameObject DialogIntroduction; // GameObject for Barkeep NPC Introduction Dialog
    public GameObject DialogGoldenBottle; // GameObject for Barkeep NPC Quest Dialog
    public GameObject DialogCleanOutside; 
    public GameObject DialogLostTreasure;


    //Quest Items
    public GameObject GoldenBottle;
    public GameObject ItemClearUp;
    public GameObject LostTreasure;

    //Barkeep SFX
    public AudioSource barkeepSFX;

    // Start is called before the first frame update
    void Start()
    {
        #region Set Bools to True or False when Game Begins
        DialogBoxBarkeep.SetActive(false); // Dad NPC Dialog Box is equal to False

        DialogIntroduction.SetActive(true);
        DialogGoldenBottle.SetActive(false);
        DialogCleanOutside.SetActive(false);
        DialogLostTreasure.SetActive(false);
        #endregion


        #region
        GoldenBottle.SetActive(false);
        ItemClearUp.SetActive(true);
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

        //Run the Quests Method
        BarkeepQuests();
    }

    public void BarkeepQuests()
    {
        bool checkCoins = false;

        if (Coin.money == 10) // If Player picks up 10 coins, continue quest
        {
            DialogIntroduction.SetActive(false);
            DialogGoldenBottle.SetActive(true);
            GoldenBottle.SetActive(true);
            checkCoins = true;
        }
        if (checkCoins == true && GoldenBottle.activeInHierarchy == false)
        {
            DialogGoldenBottle.SetActive(false);
            DialogCleanOutside.SetActive(true);
        }
        if (checkCoins == true && GoldenBottle.activeInHierarchy == false && ItemClearUp.activeInHierarchy == false)
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
            Debug.Log("Collided");
            DialogBoxBarkeep.SetActive(true); // Display Dad's Dialog Box when Player Collides with Dad NPC
            barkeepSFX.Play(0);
        }
        #endregion
    }
}
