using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvasOnLaunch : MonoBehaviour
{
    public GameObject canvas;
    public GameObject eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(true);
        eventSystem.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
