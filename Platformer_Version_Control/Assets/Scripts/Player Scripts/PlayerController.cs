using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject playerModel;
    Rigidbody my_Rigidbody;
    public float speed;
=======
    Rigidbody rb;
    public float speed = 10;
>>>>>>> Vicbranch

    void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
        playerModel.transform.Translate(new Vector3(moveHor, 0, moveVer));
    }



}
