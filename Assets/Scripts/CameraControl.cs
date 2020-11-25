using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    float rotSpeed = 0.5f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }
}
