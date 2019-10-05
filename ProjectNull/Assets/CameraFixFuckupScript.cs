using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lightbug.GrabIt;

public class CameraFixFuckupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject cameraGO = GetComponentInChildren<Camera>().gameObject;
        GetComponentInChildren<Camera>().farClipPlane = 10000;

        cameraGO.AddComponent<GrabIt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
