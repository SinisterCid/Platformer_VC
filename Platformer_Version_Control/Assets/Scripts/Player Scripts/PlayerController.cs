using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    Rigidbody my_Rigidbody;
    public float speed = 10;


    void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
      my_Rigidbody.velocity= (new Vector3(moveHor * speed , 0, moveVer * speed));
    }



}
