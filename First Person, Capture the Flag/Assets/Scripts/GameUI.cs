using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public GameObject playerHUD;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    //public Image healthBarFill;
    public TextMeshProUGUI healthText;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    private AudioSource clickAudio;
    public AudioClip click;
    private float audioDelay;

    public static GameUI instance;

    private Enemy enemy;
    private GameManager gm;

    void Awake(){
        instance = this;
        endGameScreen.SetActive(false);
        pauseMenu.SetActive(false);
    }

    void Start(){
        clickAudio = GetComponent<AudioSource>();
        audioDelay = click.length;

        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void UpdateHealthBar(int curHP, int maxHP){
        //healthBarFill.fillAmount = (float)curHP / (float)maxHP;
        healthText.text = "Health: " + curHP + " / " + maxHP;
    }

    public void UpdateScoreText(int score){
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo){
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu(bool paused){
        pauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen(bool won, int score){
        endGameScreen.SetActive(true);
        playerHUD.SetActive(false);

        //enable cursor
        Cursor.lockState = CursorLockMode.None;

        endGameHeaderText.text = won == true ? "You win!" : "You lose...";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnResumeButton(){
        clickAudio.PlayOneShot(click, 1f);
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton(){
        clickAudio.PlayOneShot(click, 1f);

        gm.SetGameOver();
        enemy.Pause(true);
        Time.timeScale = 1f;

        Invoke("Restart", audioDelay);
    }

    /*public void OnMenuButton(){ //Go back to main menu
        SceneManager.LoadScene("Menu");
    }*/

    public void OnExitButton(){
        clickAudio.PlayOneShot(click, 1f);

        gm.SetGameOver();
        enemy.Pause(true);
        Time.timeScale = 1f;

        Invoke("Exit", audioDelay);
    }


    private void Restart(){
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Level 0");
    }

    private void Exit(){
        Application.Quit(); //quits game
        Debug.Log("You have quit the game. Goodbye!");
    }
}