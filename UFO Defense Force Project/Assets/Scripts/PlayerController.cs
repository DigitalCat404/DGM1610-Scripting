using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10;

    public float xBounds = 33f;

    public Transform blaster;

    public GameObject laserBolt;
    
    //laser firing delay
    public float laserDelay = .2f;
    private float lastShotFired;


    // Update is called once per frame
    void Update()
    {
        //set horizontal to receive values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
        
        //moves player left and right   Vector3.right = X-axis
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //left bound
        if(transform.position.x < -xBounds){
            transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
       
        //right bound
        } else if(transform.position.x > xBounds){
            transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
        }

        //if spacebar is pressed, fire laser;   make sure enough time has passed before firing again
        if((Input.GetKeyDown(KeyCode.Space))&&(Time.time-lastShotFired >= laserDelay)){
            Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
            
            //track firing delay
            lastShotFired = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other){
        //delete object with trigger striking player
        Destroy(other.gameObject);
    }
}
