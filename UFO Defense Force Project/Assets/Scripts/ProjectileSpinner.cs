using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpinner : MonoBehaviour
{
    public float spinFactor = 350f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * spinFactor * Time.deltaTime);
    }
}
