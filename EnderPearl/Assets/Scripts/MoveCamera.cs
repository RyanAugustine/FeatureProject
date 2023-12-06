using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Augustine, Ryan
//12/5/23
//THis script will make the camera move into position
public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
