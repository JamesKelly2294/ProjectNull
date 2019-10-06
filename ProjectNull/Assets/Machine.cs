using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineWindow window;
    public bool canAccept = true;

    public void ObjectWasSchloinked(GameObject go)
    {
        window.DisplayObject(go);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(window.displayedObject)
        {
            window.RemoveObjectFromDisplay();
        }
    }
}
