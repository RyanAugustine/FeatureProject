using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Augustine, Ryan
//12/5/23
//This script will allow the player to throw the ender pearl.
public class Throw : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject Enderpearl;
    public GameObject currentEnderpearl;

    [Header("Settings")]
    public float throwCooldown;
    private bool PearlOut;

    [Header("Throwing")]
    public float throwForce;
    public bool readyToThrow;

    public void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        Yeet();
        TeleportNow();
    }

    private void Yeet()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (readyToThrow == true)
            {
                if (!PearlOut)
                {
                    currentEnderpearl = Instantiate(Enderpearl, attackPoint.position, Quaternion.identity) as GameObject;
                    currentEnderpearl.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);

                    PearlOut = true;
                }

                if (PearlOut)
                {
                    Destroy(currentEnderpearl);
                    currentEnderpearl = null;
                    currentEnderpearl = Instantiate(Enderpearl, attackPoint.position, Quaternion.identity) as GameObject;
                    currentEnderpearl.GetComponent<Rigidbody>().AddForce(cam.transform.forward * throwForce, ForceMode.Impulse);

                    PearlOut = true;
                }

            }

            readyToThrow = false;

            Invoke(nameof(ResetThrow), throwCooldown);

        }
   
    }

    private void TeleportNow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (PearlOut)
            {
                float teleportOffset = GetComponent<CapsuleCollider>().height / 2;
                Vector3 grenadePosition = currentEnderpearl.transform.position;
                Vector3 teleportLocation = new Vector3(grenadePosition.x, grenadePosition.y + teleportOffset, grenadePosition.z);
                transform.position = teleportLocation;
                Destroy(currentEnderpearl);
                currentEnderpearl = null;
                PearlOut = false;
            }
            if (!PearlOut)
            {
                return;
            }

        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
