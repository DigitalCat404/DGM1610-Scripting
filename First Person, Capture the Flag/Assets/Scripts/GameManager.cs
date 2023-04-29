using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;

    //public int scoreToWin;
    public int curScore;
    public int capScore;

    public bool gamePaused;
    public bool gameOver;

    public static GameManager instance;

    private PlayerController player;

    //hurry and catch the thief!
    private Enemy enemy;
    public bool rushOn;

    //called before Start, called only once
    void Awake()
    {
        instance = this;
    }

    void Start(){
        hasFlag = false;
        flagPlaced = false;
        rushOn = false;
        gameOver = false;

        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1.0f;

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if((flagPlaced)&&(!gamePaused)){
            WinGame();
        }

        if(Input.GetButtonDown("Cancel")&&(!gamePaused)){ //escape key pauses game
            TogglePauseGame();
        }

        if((hasFlag)&&(!rushOn)){
            Debug.Log("Rush mode on!");
            rushOn = true;
            enemy.SpeedUp();
        }
    }


    public void TogglePauseGame(){
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked; //hide or reveal cursor for UI
    }


    public void AddScore(int score){
        curScore += score;

        GameUI.instance.UpdateScoreText(curScore);

        /*if(curScore >= scoreToWin) //removed score criteria
            WinGame();*/
    }


    void WinGame(){
        Debug.Log("You've won the game!");
        Time.timeScale = 0.0f;
        gamePaused = true;
        gameOver = true;

        AddScore(player.curHP * 50);

        GameUI.instance.SetEndGameScreen(true, curScore);
    }


    public void LoseGame(){
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
        gameOver = true;
    }


    public void PlaceFlag(){
        flagPlaced = true;
        AddScore(capScore);
    }


    public void SetGameOver(){
        gameOver = true;
    }
}
