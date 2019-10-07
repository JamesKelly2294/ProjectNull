using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    public MachineWindow window;
    public MachineIO rejectOutput;
    public bool canAccept = true;

    public ConveyorSectorColor color = ConveyorSectorColor.black;
    protected Box box;

    public virtual void ObjectWasSchloinked(GameObject go)
    {
        box = go.GetComponent<Box>();
        if (box.Task.sorted && box.Task.sectorColor != color || !box.Task.sorted && color != ConveyorSectorColor.black)
        {
            // reject the box
            rejectOutput.YeetObject(go);
        } else
        {
            window.DisplayObject(go);
        }
    }

    public virtual void ObjectWasDisplayed(GameObject go)
    {
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
