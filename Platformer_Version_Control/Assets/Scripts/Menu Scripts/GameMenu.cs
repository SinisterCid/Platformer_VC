using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    // Function for the start button
    void StartButton()
    {

        // Load game scene when Fungus block calls for it
        SceneManager.LoadScene("GameLoopTest", LoadSceneMode.Single);
    }

    // Function for the quit button
    void QuitButton()
    {

        // Exit the game when quit button is pressed
        Application.Quit();
    }
}
