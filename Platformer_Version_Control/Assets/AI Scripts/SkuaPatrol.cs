using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkuaPatrol : StateMachineBehaviour

{

    private Transform playerPos;
    private Transform orbitPos;

    public float xSpread;
    public float zSpread;
    public float yOffset;
    public float rotSpeed;
    public bool rotateClockwise;

    float timer = 0;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        orbitPos = GameObject.FindGameObjectWithTag("Orbit").transform;

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timer += Time.deltaTime * rotSpeed;

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

        float distance = Vector3.Distance(playerPos.transform.position, animator.transform.position);

        if (distance <= 6)
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
