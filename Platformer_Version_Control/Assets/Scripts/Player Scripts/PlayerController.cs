using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //variables
    Rigidbody rb;
    public float speed = 10;


    void Start()
    {

        //Get rigidbody reference
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

        //Reference input
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        //Control movement speed using rigidbody
        rb.velocity= (new Vector3(moveHor * speed, rb.velocity.y, moveVer * speed));
    }

    //Collision to restart scene
    private void OnCollisionEnter(Collision collision)
    {

        //Once hoisted away by the Skua AI, the player will keep floating upwards until touching the Killzone
        if (collision.gameObject.tag == "Killzone")
        {

            //Restart Scene after touching the Killzone
            SceneManager.LoadScene("GameLoopTest", LoadSceneMode.Single);
        }
    }

}
