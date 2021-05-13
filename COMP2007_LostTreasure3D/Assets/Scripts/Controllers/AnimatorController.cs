using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    //Creating reference to UI Animation Scripts
    public FlashAnimation healthbarAnimationFlash;
    public SquashAnimation healthbarAnimationSquash;
    public RumbleAnimation healthbarAnimationRumble;

    //Create public audio source to assign SFX
    public AudioSource hurtSFX;

    //Create a virtual method to play the Hurt Sound Effect
    public virtual void SoundEffectHurt()
    {
        hurtSFX.Play();
    }

    //Create a virtual method to play the Healthbar Animations
    public virtual void HealthbarAnimations()
    {
        healthbarAnimationFlash.UiAnimation();
        healthbarAnimationSquash.UiAnimation();
        healthbarAnimationRumble.UiAnimation();
    }
}
