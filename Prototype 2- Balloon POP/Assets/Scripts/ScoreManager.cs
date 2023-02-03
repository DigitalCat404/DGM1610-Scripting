using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    public void IncreaseScoreText(int amount){
        score += amount;
        UpdateScoreText();
    }

    public void DecreaseScoreText(int amount){
        score -= amount;
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        scoreText.text = "Score: " + score;
    }
}