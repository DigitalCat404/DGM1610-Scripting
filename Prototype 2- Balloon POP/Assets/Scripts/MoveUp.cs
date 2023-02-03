using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float upperBound = 13;

    private ScoreManager scoreManager;
    private Balloon balloon;

    // Start is called before the first frame update
    void Start()
    {
        //get ScoreManager Component
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        //get local Balloon Script Component
        balloon = GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        //if hitting the height limit, delete
        if(transform.position.y > upperBound) {

            //deduct score, stealing value from Balloon Script
            scoreManager.DecreaseScoreText(balloon.scoreToGive);

            Destroy(gameObject); //pop balloon
        }
    }
}
