using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RumbleAnimation : MonoBehaviour, AnimationInterface
{
    //Access the PlayerHealthBar Script
    public PlayerHealth playerHealthBar = new PlayerHealth();

    #region Animation Method and IEnumerator to create Rumble effect for Healthbar
    public void UiAnimation()
    {
        //Start the IEnumerator Method
        StartCoroutine("UiAnimationProcess");
    }

    //IEnumerator Method to access the rotation component on the Players Healthbar
    public IEnumerator UiAnimationProcess()
    {
        //Access rotation and + 1 to the z-axis
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 1f);
        yield return new WaitForSeconds(0.2f);

        //Access rotation and - 1 to the z-axis
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 1f);
        yield return new WaitForSeconds(0.2f);

        //Access rotation and - 1 to the z-axis
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 1f);
        yield return new WaitForSeconds(0.2f);

        //Access rotation and + 1 to the z-axis
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 1f);
    }
    #endregion
}
