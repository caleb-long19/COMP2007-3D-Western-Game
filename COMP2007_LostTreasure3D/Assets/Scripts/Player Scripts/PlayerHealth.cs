using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Access the slider component
    public Slider healthSlider;

    //Int variables for Player health values
    private int currentPlayerHealth;
    private int maximumHealth;

    #region Get/Set Methods for the Players Max health and Current Health
    public int CurrentPlayerHealth
    {
        get
        {
            return currentPlayerHealth;
        }

        set
        {
            currentPlayerHealth = value;
        }
    }

    public int MaximumHealth
    {
        get
        {
            return maximumHealth;
        }

        set
        {
            maximumHealth = value;
        }
    }
    #endregion

    void Update()
    {
        //Allow the program to constantly update the Players Healthbar (Slider) to the current players health
        healthSlider.maxValue = maximumHealth;
        healthSlider.value = currentPlayerHealth;
    }

}