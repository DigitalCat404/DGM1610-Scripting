using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCatcher : MonoBehaviour
{
    public GameObject returnPoint;
    private PlayerController player;

    void Start(){
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            Debug.Log("Warping player");
            other.gameObject.transform.position = returnPoint.transform.position;
            other.gameObject.transform.rotation = returnPoint.transform.rotation;

            player.TakeDamage(1);
        }
    }
}
