using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{


    Rigidbody rb;
    public float speed = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");
      rb.velocity= (new Vector3(moveHor * speed, rb.velocity.y, moveVer * speed));
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Killzone")
        {

            SceneManager.LoadScene("GameLoopTest", LoadSceneMode.Single);
        }
    }

}
