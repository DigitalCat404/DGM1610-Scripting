using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Player Stats
    [Header("PlayerStats")]
    private float horizontalInput;
    public float speed = 10;
    //how high player jumps
    public float jumpForce;
    public string inventory = "";
    
    
    //Player Rigidbody
    [Header("Rigidbody Components")]
    private Rigidbody2D rb;
    private bool isFacingRight = true;


    //Player Jump
    [Header("Jump Settings")]
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool dubJump;

    //Game Objects
    [Header("Game Objects")]
    private UIManager UIManager;


    void Start(){
        //identify the rigidbody component on Player
        rb = GetComponent<Rigidbody2D>();

        UIManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    //called between a fixed number of frames, best for physics based movement
    void FixedUpdate(){
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround); //check for ground

        //set horizontal to receive values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
        //moves player left and right   Vector3.right = X-axis
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //flip player when changing left/right direction
        if((!isFacingRight && horizontalInput > 0)||(isFacingRight && horizontalInput < 0)){
            FlipPlayer();
        }
    }

    // Update is called once per frame, per cycle
    void Update(){
        if(isGrounded){dubJump = true;}

        if(Input.GetKeyDown(KeyCode.Space) && ((dubJump || isGrounded)) ){
            rb.velocity = Vector2.up * jumpForce; //make player jump
            
            //if double jumping, remove double jump
            if(!isGrounded){
                dubJump = false;
            }
        }
    }

    void FlipPlayer(){
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale; //local variable
        scaler.x *= -1; //declare flipping the sprite graphic
        transform.localScale = scaler; //perform the flip
    }

    private void OnTriggerEnter2D(Collider2D other){

        //if hit by pickup, collect and put in inventory
        if(other.tag == "Pickup"){
            inventory = other.tag;
            Debug.Log("Inventory: " + inventory);
            UIManager.IncrementPickup();

            //delete object with trigger striking player
            Destroy(other.gameObject);
            //Debug.Log("deleted collision");
        }
    }

    public void setInventory(string item){
        inventory = item;
        Debug.Log("Inventory: " + inventory);
    }
}
