using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Augustine, Ryan
//12/5/23
//This script will make the ender pearl stick to the ground
public class Teleport : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
    }
}
