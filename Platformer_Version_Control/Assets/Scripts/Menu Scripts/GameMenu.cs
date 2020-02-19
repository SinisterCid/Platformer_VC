using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void StartButton()
    {

        //Load game scene when play button is pressed
        SceneManager.LoadScene("GameLoopTest", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void QuitButton()
    {

        //Exit the game when quit button is pressed
        Application.Quit();
    }
}
