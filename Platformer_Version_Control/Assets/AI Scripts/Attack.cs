using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform player;
    public float farSpeed;
    public float closeSpeed;

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

    public void Attacking()
    {

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance >= 10)
        {

            float step1 = farSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step1);
        }

        if (distance < 10)
        {

            float step2 = closeSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step2);
        }

        if (distance <= 1.6f)
        {

            animator.SetBool("Carry", true);
        }
    }
}
