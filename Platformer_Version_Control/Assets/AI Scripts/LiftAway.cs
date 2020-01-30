using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAway : MonoBehaviour
{
    public float upSpeed;
    //public GameObject destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LiftingAway()
    {

        //float step = upSpeed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, destination.transform.position, step);
        transform.position += Vector3.up * Time.deltaTime * upSpeed;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.transform.parent = transform;
        }
    }
}
