using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Reference Camera and CharacterController script
    public CharacterController controller;
    public Transform camera;


    //Floar Variables
    public float speed = 6f;
    public float turningSmoothTime = 0.1f;
    private float turnSmoothV;


    //Particle System References
    public ParticleSystem movementParticles;


    //Audio References
    public AudioSource Running;


    //Animator References
    private Animator animator;


    void Start()
    {
        //Get animator component on gameobject
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        //Store Horizontal and Verticle values in float variables
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothV, turningSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            //Play Movement Particles and start running animation
            MovementParticles();
            animator.SetBool("isRunning", true);

            //Move Player based on direction, speed and time
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else
        {
            //Stop particles and running animation
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
            //Play particles and running sfx
            movementParticles.Play();
            Running.Play();
        }
    }

    private void StopHealingParticles()
    {
        //Stop particles and running sfx
        movementParticles.Stop();
        Running.Stop();
    }
    #endregion

}
