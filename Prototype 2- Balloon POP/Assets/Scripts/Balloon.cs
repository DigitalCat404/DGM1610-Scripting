using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int clicksToPop = 3;
    public float scaleInflation = .1f;
    public ScoreManager scoreManager;
    public int scoreToGive = 100;

    // Start is called before the first frame update
    void Start()
    {
        //get ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnMouseDown(){
        clicksToPop--;

        if(clicksToPop >= 0){ //inflate balloon
            transform.localScale += Vector3.one * scaleInflation;

        } else { //pop balloon

            //give score
            scoreManager.IncreaseScoreText(scoreToGive);

            Destroy(gameObject);
        }
    }
}
