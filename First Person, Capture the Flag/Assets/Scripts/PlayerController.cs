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

    [Header("Mouse Look")]
    public float lookSensitivity;
    public float maxLookX;  //lowest down we can look
    public float minLookX;  //highest up we can look
    private float rotX;     //current X rotation of camera

    //References
    private Camera camera;
    private Rigidbody rb;
    //private Weapon weapon;


    void Awake(){
        //weapon = GetComponent<Weapon>();
        curHP = maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();

        /* Initialize UI
        GameUI.instnace.UpdateHealthBar(curHP, maxHP);
        GameUI.instance.UpdateScoreText(0);
        GameUI.instance.UpdateAmmoText(weapon.curAmmo, weapon.maxAmmo); */
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();

        if(Input.GetKeyDown("space")){
            Jump();
        }

        //Fire weapon
    }


    void Move(){
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        //move by manipulating rigidbody relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;

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

        if(curHP <= 0){
            //Die();
        }
    }

    public void GiveHealth(int heal){
        Debug.Log("Player healed " + heal);
        
        curHP += heal;
        if(curHP > maxHP){
            curHP = maxHP;
        }
    }

    public void GiveAmmo(int rounds){}
}
