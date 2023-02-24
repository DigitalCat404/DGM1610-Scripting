using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText; //the text UI element to change

    void Start(){
        UpdateScoreText();
    }

    public void IncreaseScore(int amount){
        score += amount;
        UpdateScoreText(); //update UI
    }

    public void DecreaseScore(int amount){
        score -= amount;
        UpdateScoreText(); //update UI
    }

    public void UpdateScoreText(){
        scoreText.text = "Score: " + score;
    }
}