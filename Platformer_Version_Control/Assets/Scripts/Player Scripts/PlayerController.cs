﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PlayerController : MonoBehaviour
{

    //variables
    Rigidbody rb;
    public float speed;
    public bool canControl = true;
    float flying;
    public int shellCounter;
    public Text shellText;

    //Analytics
    int numDeaths = 0;
    int numRestarts = 0;

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

            // Getting the direction to move through player input
            float hMove = Input.GetAxis("Horizontal");
            float vMove = Input.GetAxis("Vertical");

            // Get directions relative to camera
            Vector3 forward = Camera.main.transform.forward;
            Vector3 right = Camera.main.transform.right;

            // Project forward and right direction on the horizontal plane (not up and down), then
            // normalize to get magnitude of 1
            forward.y = 0;
            right.y = 0;
            forward.Normalize();
            right.Normalize();

            // Set the direction for the player to move
            Vector3 dir = right * hMove + forward * vMove;

            // Set the direction's magnitude to 1 so that it does not interfere with the movement speed
            dir.Normalize();

            // Move the player by the direction multiplied by speed and delta time 
            transform.position += dir * speed * Time.deltaTime;

            // Set rotation to direction of movement if moving
            if (dir != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), 0.2f);
            }
        }
    }

    void Update()
    {

        //if player has control, press space to spin attack
        if (Input.GetKeyDown(KeyCode.Space) && canControl == true)
        {

            StartCoroutine(Rotate(0.3f));
        }

        //if lifted up by skua, disable controls
        if (transform.position.y > flying)
        {

            canControl = false;
        }

        //press R to restart scene
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene("GameLoopTest", LoadSceneMode.Single);

            // Analytics for restart
            numRestarts++;
            ReportRestarts(numRestarts);
        }

    }

    //spin player character and child stick 360 degrees over time after space is pressed
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

            //Analytics for deaths
            numDeaths++;
            ReportPlayerDeaths(numDeaths);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //if player character touches seashell, destroy seashell and add point
        if (other.gameObject.tag == "Collect")
        {

            shellCounter++;
            Destroy(other.gameObject);

            shellText.text = "Seashells: " + shellCounter;

            //Analytics for collectables
            ReportCollectablesCollected(shellCounter);
        }
    }

    // Reprots for how many shells have been collected by the player
    public void ReportCollectablesCollected(int collectables)
    {
        Analytics.CustomEvent("pickUp", new Dictionary<string, object>
            {
                {"pickUp_Num", collectables}
            });
    }

    // Reports for how many deaths the player had
    public void ReportPlayerDeaths(int deaths)
    {
        Analytics.CustomEvent("playerDeaths", new Dictionary<string, object>
        {
            {"died", deaths},
            {"timeElapsed", Time.timeSinceLevelLoad}
        });
    }

    public void ReportRestarts(int restart)
    {
        Analytics.CustomEvent("restarts", new Dictionary<string, object>
        {
            {"restarted", restart},
            {"timeElapsed", Time.timeSinceLevelLoad}
        });
    }
}
