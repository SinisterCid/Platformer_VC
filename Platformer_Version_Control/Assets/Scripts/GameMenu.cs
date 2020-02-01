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
        SceneManager.LoadScene("Playscene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void QuitButton()
    {
        Application.Quit();
    }
}
