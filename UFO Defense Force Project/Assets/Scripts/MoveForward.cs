using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 50f;

    // Update is called once per frame
    void Update()
    {
        //move object forward   forward = X axis
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }
}
