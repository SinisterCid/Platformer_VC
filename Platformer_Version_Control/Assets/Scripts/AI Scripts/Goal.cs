using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{

    //On collision with player
    private void OnCollisionEnter(Collision collision)
    {
        
        //If the object tagged "player" collides with the collectible, change scene to the main menu
        if (collision.gameObject.tag == "Player")
        {

            //Load the menu scene
            SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);
        }
    }
}
