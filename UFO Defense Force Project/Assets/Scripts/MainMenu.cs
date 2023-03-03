using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;

    //audio
    private AudioSource clickAudio;
    public AudioClip click;

    private float audioDelay = 0.75f;

    void Start(){
        clickAudio = GetComponent<AudioSource>();
    }

    public void StartGame(){
        clickAudio.PlayOneShot(click, 1f);
        Invoke("RevUp", audioDelay);
        
    }

    public void QuitGame(){
        clickAudio.PlayOneShot(click, 1f);
        Invoke("Exit", audioDelay);
    }

    private void RevUp(){
        SceneManager.LoadScene(sceneToLoad); //indexed scene to load
        Debug.Log("New scene loaded!");
    }

    private void Exit(){
        Application.Quit(); //quits game
        Debug.Log("You have quit the game. Goodbye!");
    }
}