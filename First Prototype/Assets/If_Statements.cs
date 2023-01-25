using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class If_Statements : MonoBehaviour
{
    public int captainAmerica = 50;
    public int batman = 30;

    public char input = 'W';

    public string bestNERFgun= "Gjallarhorn";

    public bool truth = true;


    // Start is called before the first frame update
    void Start()
    {
        if(captainAmerica > batman){
            Debug.Log("Captain America is better than Batman");
        } else {
            Debug.Log("Batman is better!");
        }

        if(bestNERFgun == "Gjallarhorn"){
            Debug.Log("The best NERF gun is the Gjallarhorn");
        }

        if(truth){
            Debug.Log("The truth is true");
            truth = false;
        }

        if((input == 'W') && (!truth)){
            Debug.Log("Move forward to get that W");
        }

        if(captainAmerica * 0.2 == batman / 3){
            Debug.Log("Maybe Captain America could equal Batman...");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
