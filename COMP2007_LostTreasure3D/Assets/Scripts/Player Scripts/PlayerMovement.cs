using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;

    public float speed = 6f;
    public float turningSmoothTime = 0.1f;
    float turnSmoothV;
    public ParticleSystem movementParticles;

    public AudioSource Running;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothV, turningSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            MovementParticles();
            animator.SetBool("isRunning", true);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            StopHealingParticles();
            animator.SetBool("isRunning", false);
        }
    }

    #region Start and Stop Healing Particles
    private void MovementParticles()
    {
        //If the particles are not playing, play the particle animation
        if (!movementParticles.isPlaying)
        {
            //Wait 1 second and run the Stop healing particles 
            movementParticles.Play();
            Running.Play();
        }
    }

    private void StopHealingParticles()
    {
        movementParticles.Stop();
        Running.Stop();
    }
    #endregion

}
