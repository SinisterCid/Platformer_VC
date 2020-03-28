using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol4 : StateMachineBehaviour
{

    //Get position of player and origin in which skua will orbit around
    private Transform playerPos;
    private Transform orbitPos;

    //Variables to determine parameters of the orbiting
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public float rotSpeed;
    public bool rotateClockwise;
    public float distanceToAttack;
    float timer = 0;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Reference player and orbit origin point
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        orbitPos = GameObject.FindGameObjectWithTag("Orbit4").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Determine speed
        timer += Time.deltaTime * rotSpeed;

        //Rotation pattern and direction
        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            animator.transform.position = pos + orbitPos.position;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            animator.transform.position = pos + orbitPos.position;
        }

        //Measure distance between skua and player
        float distance = Vector3.Distance(playerPos.transform.position, animator.transform.position);

        //If player is within a certain distance, set bool to change to attack state
        if (distance <= distanceToAttack)
        {

            animator.SetBool("SpotTarget", true);
        }

    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    ////OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    ////OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

