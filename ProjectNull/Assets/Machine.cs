using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineWindow window;
    public bool canAccept = true;

    public ConveyorSectorColor color = ConveyorSectorColor.black;
    protected Box box;

    public virtual void ObjectWasSchloinked(GameObject go)
    {
        window.DisplayObject(go);
    }

    public virtual void ObjectWasDisplayed(GameObject go)
    {
        box = go.GetComponent<Box>();
    }

    public virtual void ObjectWasRemovedFromDisplay (GameObject go)
    {

    }

    public virtual void ObjectWasSchlorped(GameObject go)
    {
        box = null;
        canAccept = true;
    }

    public virtual void ObjectWasYeeted(GameObject go)
    {
        box = null;
        canAccept = true;
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
