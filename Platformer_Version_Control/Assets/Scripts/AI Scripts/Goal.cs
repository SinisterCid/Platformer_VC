using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;

public class Goal : MonoBehaviour
{
    int numberOfCompletion = 0;

    //When player collides with the goal
    void OnTriggerEnter(Collider other)
    {
        //If the object tagged "player" collides with the end goal, change scene to the endscene
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("EndScene", LoadSceneMode.Single);

            numberOfCompletion++;
            // Analytics for game end
            ReportGameEnd();
        }
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
