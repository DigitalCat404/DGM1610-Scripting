using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlag : MonoBehaviour
{
    public GameObject grabFX;
    public GameObject FXPoint;

    public int stealScore;

    private GameManager gm;
    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        gm.hasFlag = true;
        gm.AddScore(stealScore);

        rend.enabled = false; //hide flag
        foreach(Renderer r in gameObject.GetComponentsInChildren<Renderer>()) { r.enabled = false; }

        Instantiate(grabFX, FXPoint.transform.position, FXPoint.transform.rotation);
    }
}