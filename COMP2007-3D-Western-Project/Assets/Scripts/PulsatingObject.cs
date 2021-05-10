using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsatingObject : MonoBehaviour
{
    private bool allowPulse;


    // Start is called before the first frame update
    void Start()
    {
        allowPulse = true;
    }

    private void OnMouseOver()
    {
        if (allowPulse)
        {
            StartCoroutine("PulseObject");
        }
    }

    private IEnumerator PulseObject()
    {
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
