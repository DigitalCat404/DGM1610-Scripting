using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectile;

    public float cooldown = 0.3f;
    private float lastShot;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")&&(Time.time > lastShot + cooldown)){
            lastShot = Time.time;
            Fireball();
        }
    }

    void Fireball(){
        Instantiate(projectile, firePoint.position, firePoint.rotation);
    }
}