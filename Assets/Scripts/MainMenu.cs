using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quit!"); // This is just for testing purposes
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene(1);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(3);
    }
}
