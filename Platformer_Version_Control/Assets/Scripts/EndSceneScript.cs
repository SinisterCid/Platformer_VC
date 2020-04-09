using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneScript : MonoBehaviour
{
    public void Endgame()
    {
        //Load the menu scene
        SceneManager.LoadScene("GameMenu", LoadSceneMode.Single);
    }

}
