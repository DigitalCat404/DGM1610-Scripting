using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;

    public void StartGame(){
        SceneManager.LoadScene(sceneToLoad); //indexed scene to load
        Debug.Log("New scene loaded!");
    }

    public void QuitGame(){
        Application.Quit(); //quits game
        Debug.Log("You have quit the game. Goodbye!");
    }
}