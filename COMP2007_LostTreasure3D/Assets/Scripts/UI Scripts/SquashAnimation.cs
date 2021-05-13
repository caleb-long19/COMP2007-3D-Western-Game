using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquashAnimation : MonoBehaviour, AnimationInterface
{
    //Add a slider scale bar on the Script to adjust the scaleSpeed variable
    [Range(0.1f, 1f)]
    public float scaleSpeed = 1f;

    //Access the PlayerHealthBar Script
    public PlayerHealth playerHealthBar = new PlayerHealth();

    #region Animation Method and IEnumerator to create Squash effect for Healthbar
    public void UiAnimation()
    {
        //Start the IEnumerator Method
        StartCoroutine("UiAnimationProcess");
    }

    //IEnumerator Method to access the scale component on the Players Healthbar
    public IEnumerator UiAnimationProcess()
    {
        //Access scale and + 0.5 to the x-axis and + 0.5 to the y-axis
        transform.localScale = new Vector3(transform.localScale.x + 0.5f * scaleSpeed, transform.localScale.y + 0.5f * scaleSpeed, 0);

        //Pause for 0.1 Seconds
        yield return new WaitForSeconds(0.1f);

        //Access scale and - 0.5 to the x-axis and - 0.5 to the y-axis
        transform.localScale = new Vector3(transform.localScale.x - 0.5f * scaleSpeed, transform.localScale.y - 0.5f * scaleSpeed, 0);
        yield return new WaitForSeconds(0.1f);


        transform.localScale = new Vector3(transform.localScale.x - 0.5f * scaleSpeed, transform.localScale.y - 0.5f * scaleSpeed, 0);
        yield return new WaitForSeconds(0.1f);


        transform.localScale = new Vector3(transform.localScale.x + 0.5f * scaleSpeed, transform.localScale.y + 0.5f * scaleSpeed, 0);
    }
    #endregion
}