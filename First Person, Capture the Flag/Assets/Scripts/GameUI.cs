using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText;
    //public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;

    public static GameUI instance;

    void Awake(){
        instance = this;
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
        endGameHeadertext.text = won == true ? "You win!" : "You lose...";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnResumeButton(){
        GameManager.instance.TogglePauseGame();
    }

    public void OnRestartButton(){
        ScoreManager.LoadScene("Level 0"); //was "Game"
    }

    public void OnMenuButton(){
        SceneManager.LoadScene("Menu");
    }
}