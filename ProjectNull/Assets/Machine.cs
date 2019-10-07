using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineWindow window;
    public bool canAccept = true;
    
    protected Box box;

    public void ObjectWasSchloinked(GameObject go)
    {
        window.DisplayObject(go);
    }

    public void ObjectWasDisplayed(GameObject go)
    {
        box = go.GetComponent<Box>();
    }

    public void ObjectWasRemovedFromDisplay (GameObject go)
    {

    }

    public void ObjectWasSchlorped(GameObject go)
    {
        box = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
