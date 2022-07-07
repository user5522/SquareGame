using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    public void ExitButton(){
        Application.Quit();
        Debug.Log("Exit Button Pressed"); // This is just for testing purposes
    }

    public void StartButton(){
        SceneManager.LoadScene("TutorialLevel");
    } 
}
