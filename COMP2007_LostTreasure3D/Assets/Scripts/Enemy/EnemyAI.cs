using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Variables
    public int EnemyHealth; // enemy health

    [SerializeField]
    public float EnemySpeed = 5.0f; // Speed of the Enemy

    [SerializeField]
    private float MinEnemyRange = 0; // Minimum range the Enemy can spot player

    [SerializeField]
    private float MaxEnemyRange = 0; // Maximum range the Enemy can spot player



    //Unity References
    private Animator EnemyMovement; // Reference to Unity Animator
    private Transform Target; // Reference to Player position
    public AudioSource EnemySFX; // Create an AudioSource Accessor for the Attack SFX


    public void Start()
    {
        EnemyMovement = GetComponent<Animator>(); // EnemyMovement is equal to Animator Component on gameObject
        Target = FindObjectOfType<PlayerMovement>().transform; // Target is equal to Player
    }


    private void Update()
    {
        if (Vector3.Distance(Target.position, transform.position) <= MaxEnemyRange && Vector3.Distance(Target.position, transform.position) >= MinEnemyRange)
        {
            TrackPlayer(); // If the Players Positon is out of the Enemies Max Range && the Player is above the Enemies Minimum Range, run the Track Player Method
        }
        else
        {
            EnemyMovement.SetBool("enemyIsMoving", false); //Activate the moving animation for the Enemy
        }

    }


    public void TrackPlayer()
    {
        EnemyMovement.SetBool("enemyIsMoving", true); // Sets Animator "enemyIsMoving" Parameter to True
        EnemyMovement.SetFloat("Horizontal", (Target.position.x - transform.position.x)); // Enemies Horzontal Position
        EnemyMovement.SetFloat("Vertical", (Target.position.y - transform.position.y)); // Enemies Vertical Position
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, EnemySpeed * Time.deltaTime); // Transforms Enemies Position to Players Position
        FaceTarget();
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player")) //If Enemy collides with Player character
        {
            //Play SFX and Activate Enemies Attack Animation
            EnemySFX.Play(0);
            EnemyMovement.SetBool("enemyIsMoving", false);
            EnemyMovement.SetBool("enemyIsAttacking", true);


            Debug.Log("Player Has Collided!"); // Display Debug Log in Console
        }
        else
        {
            EnemyMovement.SetBool("enemyIsAttacking", false);
            EnemyMovement.SetBool("enemyIsMoving", true);
        }
    }


    void FaceTarget()
    {
        //Face the Enemy Model towards the Player
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
