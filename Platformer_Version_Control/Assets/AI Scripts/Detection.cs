using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public GameObject player;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Detect()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 6)
        {

            animator.SetBool("SpotTarget", true);
        }

    }

    public void ResetPatrol()
    {

        animator.SetBool("SpotTarget", false);
        animator.SetBool("Hurt", false);
    }
}
