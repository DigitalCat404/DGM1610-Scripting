using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int healthAmount;
    public int ammoAmount;
    public int score;

    [Header("Bobbing Motion")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private bool bobbingUp;
    private Vector3 startPos;

    //public AudioClip pickupSFX;

    private GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        //spin pickup on Y-Axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        //establishes height offset, go up if true else go down
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHeight / 2, 0) : new Vector3(0, -bobHeight / 2, 0));

        //execute movement towards offset
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        //once hit offset location, reverse direction
        if(transform.position == startPos + offset){
            bobbingUp = !bobbingUp;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            PlayerController player = other.GetComponent<PlayerController>();

            switch(type){
                case PickupType.Health:
                    player.GiveHealth(healthAmount);
                break;

                case PickupType.Ammo:
                    //player.GiveAmmo(ammoAmount);
                break;

                default:
                    print("Type not accepted");
                break;
            }

            //play sound effect
            //other.getComponent<AudioSource>().PlayOneShot(pickupSFX);

            gm.AddScore(score);

            Destroy(gameObject);
        }
    }
}
