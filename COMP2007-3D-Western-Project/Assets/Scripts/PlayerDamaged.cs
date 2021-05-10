using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamaged : AudioController
{

    //Reference the PlayerHealthBar script
    public PlayerHealth playerHealth;

    #region Start and Update Methods
    void Start()
    {
        //When the game starts - Set the players health to the max amount (100)
        playerHealth.MaximumHealth = 100;
        playerHealth.CurrentPlayerHealth = playerHealth.MaximumHealth;
    }

    void Update()
    {
        //If the player press the down arrow key, Damage the player & run the following methods
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Run the Damage Player method and damage the player by 10 points
            DamagePlayer(10);
            SoundEffectHurt();

        }
        //If the player press the Up arrow key, Heal the player & run the following methods
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Run the Heal Player method and heal the player by 10 points
            HealPlayer(10);
            SoundEffectHeal();
        }
    }
    #endregion


    #region Damage and Heal Player Methods
    void DamagePlayer(int damagePlayer)
    {
        //Take the current player health and decrease by set int value
        playerHealth.CurrentPlayerHealth -= damagePlayer;

        //if the health is less than 0 - reset to 0
        if (playerHealth.CurrentPlayerHealth <= 0)
        {
            playerHealth.CurrentPlayerHealth = 0;
        }
    }

    void HealPlayer(int healPlayer)
    {
        //Take the current player health and increase by set int value
        playerHealth.CurrentPlayerHealth += healPlayer;

        //if the health is above 100 - reset to 100
        if (playerHealth.CurrentPlayerHealth >= 100)
        {
            playerHealth.CurrentPlayerHealth = 100;
        }
    }
    #endregion



    #region Virtual Methods
    public override void SoundEffectHurt()
    {
        //Access the virtual method from the AnimatorController method and run the hurt SFX
        base.SoundEffectHurt();
    }

    public override void SoundEffectHeal()
    {
        //Access the virtual method from the AnimatorController method and run the heal SFX
        base.SoundEffectHeal();
    }
    #endregion

}