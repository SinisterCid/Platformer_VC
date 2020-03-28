using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    //variables
    Rigidbody rb;
    public float speed = 10;
    public bool canControl = true;
    float flying;


    void Start()
    {

        //Get rigidbody reference
        rb = GetComponent<Rigidbody>();

        //variables to lock movement being lifted
        canControl = true;
        flying = transform.position.y;
    }
    void FixedUpdate()
    {

        if(canControl == true)
        {

            //Reference input
            float moveHor = Input.GetAxis("Horizontal");
            float moveVer = Input.GetAxis("Vertical");

            //Control movement speed using rigidbody
            rb.velocity = (new Vector3(moveHor * speed, rb.velocity.y, moveVer * speed));
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && canControl == true)
        {

            StartCoroutine(Rotate(0.3f));
        }

        if (transform.position.y > flying)
        {

            canControl = false;
        }
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation - 360.0f;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
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
