using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject Enderpearl;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwwUpwardForce;

    public bool readyToThrow;

    public void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Yeet();
        }
    }

    private void Yeet()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(Enderpearl, attackPoint.position, cam.rotation);

        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        //Implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
       
        readyToThrow = true;
    
    }

    private void ResetThrow()
    {

    }
}
