using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("Home Pole").GetComponent<Renderer>();

        flagRend.enabled = false;
        foreach(Renderer r in gameObject.GetComponentsInChildren<Renderer>()) { r.enabled = false; }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && gm.hasFlag){
            Debug.Log("Player has reached home base!");
            //gm.PlaceFlag();
            flagRend.enabled = true;
            foreach(Renderer r in gameObject.GetComponentsInChildren<Renderer>()) { r.enabled = true; }
        }
    }
}
