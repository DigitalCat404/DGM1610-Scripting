using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //control
    private float horizontalInput;
    public float speed = 10;

    public float xBounds = 33f;

    //laser
    public Transform blaster;

    public GameObject laserBolt;

    //Audio
    private AudioSource blasterAudio;
    public AudioClip laserShoot;

    private string inventory = "";
    
    //laser firing delay
    public float laserDelay = .2f;
    private float lastShotFired;

    void Start(){
        blasterAudio = GetComponent<AudioSource>();
    }


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

        LaserBlaster();
    }

    private void OnTriggerEnter(Collider other){

        //if hit by pickup, collect and put in inventory
        if(other.tag == "Pickup"){
            inventory = other.tag;
            Debug.Log("Inventory: " + inventory);

            //delete object with trigger striking player
            Destroy(other.gameObject);
            //Debug.Log("deleted collision");

        //if hitting a UFO
        } else if(other.gameObject.CompareTag("UFO")){
            Debug.Log("Ouch!");
        }

        
    }

    private void LaserBlaster(){
        //if spacebar is pressed, fire laser;   make sure enough time has passed before firing again
        //replaced GetKeyDown with GetKey to enable "full auto"
        if((Input.GetKey(KeyCode.Space))&&(Time.time-lastShotFired >= laserDelay)){
            Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
            
            //play sound effect
            blasterAudio.PlayOneShot(laserShoot, 1f);

            //track firing delay
            lastShotFired = Time.time;
        }
    }
}
