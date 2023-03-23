using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1;

        public void TakeDamage(int damage){
        health -= damage;

        if(health <= 0){
            Debug.Log(gameObject.tag + " perished");
            Destroy(gameObject);
            //while destroying and instantiating is fine, you should recycle to reduce restrain
        } else {
            Debug.Log(gameObject.tag + " took " + damage);
        }
    }
}
