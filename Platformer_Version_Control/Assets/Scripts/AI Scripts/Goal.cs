using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using Fungus;

public class Goal : MonoBehaviour
{
    int numberOfCompletion = 0;
    //public Flowchart endgame;

    //On collision with player
    private void OnCollisionEnter(Fungus.Collision collision)
    {
        
        //If the object tagged "player" collides with the collectible, change scene to the main menu
        if (collision.gameObject.tag == "Player")
        {
            //SendMessage();       
            numberOfCompletion++;
        }
    }

    //public void SendMessage()
    //{
      //  endgame.SendFungusMessage("EndGame");
    //}

    public void Endgame()
    {
        //Load the menu scene
        SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);

        // Analytics for game end
        ReportGameEnd();
    }

    // Reports how many players complete the game and how long
    public void ReportGameEnd()
    {
        AnalyticsEvent.GameOver("completedTimes", new Dictionary<string, object>
        {
            {"completed", numberOfCompletion},
            {"timeElapsed", Time.timeSinceLevelLoad}
        });
    }
}
