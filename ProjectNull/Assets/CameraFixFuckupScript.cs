using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFixFuckupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Camera>().farClipPlane = 4000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
