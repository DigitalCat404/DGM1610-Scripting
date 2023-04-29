using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed; //units per second
    public float jumpForce;

    public int maxHP;
    public int curHP;
    private Vector3 dir;

    [Header("Mouse Look")]
    public float lookSensitivity;
    public float maxLookX;  //lowest down we can look
    public float minLookX;  //highest up we can look
    private float rotX;     //current X rotation of camera

    //References
    private Camera camera;
    private Rigidbody rb;
    //private Weapon weapon;
    private GameUI gameUI;
    private GameManager gm;
    public AudioClip oofClip;
    private AudioSource hitSound;


    void Awake(){
        //weapon = GetComponent<Weapon>();

        curHP = maxHP;
        gameUI = GameObject.Find("Game UI").GetComponent<GameUI>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        hitSound = GetComponent<AudioSource>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        // Initialize UI
        GameUI.instance.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);

        //GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo);
        GameUI.instance.UpdateAmmoText(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameOver != true){ //freeze player when game's over
            Move();
            
            if(gm.gamePaused != true) //prevent camera moving in menus
                CamLook();

            if(Input.GetKeyDown("space"))
                Jump();

        } else { //lock down momentum when paused
            dir.x = 0f;
            dir.y = 0f;
            dir.z = 0f;
            rb.velocity = dir;
            rb.useGravity = false;
        }

        //Fire weapon
    }


    void Move(){
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //move by manipulating rigidbody relative to camera
        dir = transform.right * x + transform.forward * z;

        dir.y = rb.velocity.y;
        rb.velocity = dir;  //apply force in direction of camera
    }


    void CamLook(){
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        //clamp restricts movement of camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //use .eulerAngles over .Rotate
        camera.transform.localRotation = Quaternion.Euler(-rotX,0,0);
        transform.eulerAngles += Vector3.up * y;
    }


    void Jump(){
        Ray ray = new Ray(transform.position, Vector3.down);

        //if on ground, allow jump
        if(Physics.Raycast(ray, 1.1f)){
            //add force to jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    
    public void TakeDamage(int damage){
        curHP -= damage;

        Debug.Log("Player took " + damage);

        hitSound.PlayOneShot(oofClip, 1f);

        GameUI.instance.UpdateHealthBar(curHP, maxHP);

        if(curHP <= 0){
            Die();

        } else { //slow down game and give player time to adjust to situation
            Time.timeScale = 0.5f;
            Invoke("HitSlowdownReturn", 0.75f);
            /* Since Invoke is based on game time, pausing the game does not interfere
            However this does mean pausing the game will reset time to normal early!
            */
        }
    }


    private void HitSlowdownReturn(){
        Time.timeScale = 1f;
        Debug.Log("Time returned to normal");
    }


    public void GiveHealth(int heal){
        Debug.Log("Player healed " + heal);
        
        curHP += heal;
        if(curHP > maxHP){
            curHP = maxHP;
        }

        GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }

    void Die(){
        gm.LoseGame();
    }

    //public void GiveAmmo(int rounds){}
}
