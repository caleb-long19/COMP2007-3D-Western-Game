using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface AnimationInterface
{
    // Interface used on UI Elements and Scripts

    void UiAnimation();

    IEnumerator UiAnimationProcess();
}