using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;

    bool pressForward;
    bool pressBackwards;
    bool pressLeft;
    bool pressRight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        pressForward = Input.GetKey("w");
        pressBackwards = Input.GetKey("s");
        pressLeft = Input.GetKey("a");
        pressRight = Input.GetKey("d");
    }

    // Update is called once per frame
    void Update()
    {

        if (pressForward || pressBackwards || pressLeft || pressRight)
        {
            animator.SetBool("isRunning", true);
        }
    }
}
