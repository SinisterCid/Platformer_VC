using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    // Start is called before the first frame update
    public void StartButton()
    {
        StartCoroutine(WaitButton());      
    }

    IEnumerator WaitButton()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Playscene", LoadSceneMode.Single);

    }

    // Update is called once per frame
    public void QuitButton()
    {
        Application.Quit();
    }
}
