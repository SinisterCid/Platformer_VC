using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retreat : MonoBehaviour
{

    public Transform origin;
    public float speed;

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

    public void Retreating()
    {

        float distance = Vector3.Distance(origin.transform.position, transform.position);

        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, origin.position, step);

        if (distance <= 1.5f)
        {

            animator.SetBool("SpotTarget", false);
            animator.SetBool("Hurt", false);
        }
    }
}
