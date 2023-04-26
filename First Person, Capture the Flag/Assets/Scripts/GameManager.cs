using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    public int scoreToWin;
    public int curScore;

    public bool gamePaused;

    public static GameManager instance;

    //called before Start, called only once
    void Awake()
    {
        instance = this;
    }

    void Start(){
        hasFlag = false;
        flagPlaced = false;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(flagPlaced){
            WinGame();
        }

        if(Input.GetButtonDown("Cancel")){ //escape key pauses game
            TogglePauseGame();
        }
    }


    public void TogglePauseGame(){
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //GameUI.instance.TogglePauseMenu(gamePaused);
        //Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked; //hide or reveal cursor for UI
    }


    public void AddScore(int score){
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);

        if(curScore >= scoreToWin)
            WinGame();
    }


    void WinGame(){
        Debug.Log("You've won the game!");
        //Time.timeScale = 0;

        GameUI.instance.SetEndGameScreen(true, curScore);
    }


    public void LoseGame(){
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }


    public void PlaceFlag(){
        flagPlaced = true;
    }
}
