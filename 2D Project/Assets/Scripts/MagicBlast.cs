using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast : MonoBehaviour
{
    public float speed = 7;
    public int damage = 1;
    public float travelTime = 5;
    private float creationTime;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        creationTime = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate(){
        rb.velocity = transform.right * speed * Time.deltaTime; //adds velocity, moves it forward
    
        if(Time.time > creationTime + travelTime){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Enemy enemy = other.GetComponent<Enemy>();

        //currently double-hits on 2 rigidbody objects like patroller
        if(other.gameObject.CompareTag("Enemy")){
            enemy.TakeDamage(damage);
        }

        if(!other.gameObject.CompareTag("Pickup")){
            Destroy(gameObject); //remove projectile
        }
    }
}