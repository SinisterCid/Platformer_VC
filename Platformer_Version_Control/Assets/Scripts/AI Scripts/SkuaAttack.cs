using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkuaAttack : StateMachineBehaviour
{

    //Variables
    private Transform playerPos;
    private Transform stickPos;
    public float speed;
    public float minCarryDistance;
    public float minStickDistance;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Reference player and stick positions
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        stickPos = GameObject.FindGameObjectWithTag("Stick").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Move towards the player at X speed
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        //Measure distance between skua and player + skua and stick
        float distance = Vector3.Distance(playerPos.transform.position, animator.transform.position);
        float distanceToStick = Vector3.Distance(stickPos.transform.position, animator.transform.position);

        //If the player is within a certain distance to the skua, set bool and change to lift away state
        if (distance <= minCarryDistance)
        {

            animator.SetBool("Carry", true);
        }

        //If the player is within a certain distance to the stick, set bool and change to retreat state
        if (distanceToStick <= minStickDistance)
        {

            animator.SetBool("Hurt", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //// OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    //// OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
