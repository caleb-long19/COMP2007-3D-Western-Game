using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingObject : MonoBehaviour, AnimationInterface
{
    private bool allowPulse;


    // Start is called before the first frame update
    void Start()
    {
        allowPulse = true;
    }


    private void OnMouseOver()
    {
        //When User hovers over button, run pulsing animation
        if (allowPulse)
        {
            UiAnimation();
        }
        else
        {
            StopCoroutine("UiAnimationProcess");
        }
    }

    #region Animation Method and IEnumerator to create Rumble effect for Healthbar
    public void UiAnimation()
    {
        StartCoroutine("UiAnimationProcess");
    }
    #endregion


    public IEnumerator UiAnimationProcess()
    {
        //Run a for loop to begin pulse animation on button object by increasing/decreasing the scale
        allowPulse = false;

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.015f, Mathf.SmoothStep(0f, 1.5f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.015f, Mathf.SmoothStep(0f, 1.5f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.015f, Mathf.SmoothStep(0f, 1.5f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector3(
                (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.015f, Mathf.SmoothStep(0f, 1.5f, i))),
                (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.015f, Mathf.SmoothStep(0f, 1.5f, i))),
                (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.015f, Mathf.SmoothStep(0f, 1.5f, i)))
                );
            yield return new WaitForSeconds(0.015f);
        }

        allowPulse = true;
    }
}
