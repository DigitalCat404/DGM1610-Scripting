using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public int clicksToPop = 3;
    public float scaleInflation = .1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown(){
        clicksToPop--;

        if(clicksToPop >= 0){ //inflate balloon
            transform.localScale += Vector3.one * scaleInflation;

        } else { //pop balloon
            Destroy(gameObject);
        }
    }
}
