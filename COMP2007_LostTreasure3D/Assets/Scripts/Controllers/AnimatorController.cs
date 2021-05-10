using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    //Creating reference to UI Animation Scripts
    public FlashAnimation healthbarAnimations;

    //Create public audio source to assign SFX
    public AudioSource hurtSFX;
    public AudioSource healSFX;

    //Create a virtual method to play the Hurt Sound Effect
    public virtual void SoundEffectHurt()
    {
        hurtSFX.Play();
    }

    //Create a virtual method to play the Heal Sound Effect
    public virtual void SoundEffectHeal()
    {
        healSFX.Play();
    }

    //Create a virtual method to play the Healthbar Animations
    public virtual void HealthbarAnimations()
    {
        healthbarAnimations.UiAnimation();
    }
}
