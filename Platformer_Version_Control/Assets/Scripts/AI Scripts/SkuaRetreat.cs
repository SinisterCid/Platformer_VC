using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkuaRetreat : StateMachineBehaviour
{

    //Variables
    private Transform nestPos;
    public float speed;
    public float stopDistance;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Reference origin of orbit
        nestPos = GameObject.FindGameObjectWithTag("Nest").transform;
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Distance between origin of orbit and current position of skua
        float distance = Vector3.Distance(nestPos.position, animator.transform.position);

        //Move towards origin of orbit at X speed
        float step = speed * Time.deltaTime;
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, nestPos.position, step);

        //If distance to origin or orbit is small enough, set animation bools to false and return to patrol state
        if (distance <= stopDistance)
        {

            animator.SetBool("SpotTarget", false);
            animator.SetBool("Hurt", false);
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
