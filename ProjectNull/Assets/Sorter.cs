using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : Machine
{

    public MachineIO input;
    public MachineIO redOutput;
    public MachineIO greenOutput;
    public MachineIO blueOutput;

    public void RedButtonWasPressed()
    {
        ValidateBox(ConveyorSectorColor.red);
    }

    public void GreenButtonWasPressed()
    {
        ValidateBox(ConveyorSectorColor.green);
    }

    public void BlueButtonWasPressed()
    {
        ValidateBox(ConveyorSectorColor.blue);
    }

    public override void ObjectWasRemovedFromDisplay(GameObject go)
    {
        if (targetOutput == null)
        {
            return;
        }

        if(targetOutput == input)
        {
            targetOutput.YeetObject(box.gameObject);
        } else
        {
            box.MarkAsSorted();
            targetOutput.SchlorpObject(box.gameObject);
        }
    }

    private MachineIO targetOutput;
    private void ValidateBox(ConveyorSectorColor color)
    {
        if(!box) { return; }

        switch (color)
        {
            case ConveyorSectorColor.red:
                targetOutput = redOutput;
                break;
            case ConveyorSectorColor.green:
                targetOutput = greenOutput;
                break;
            case ConveyorSectorColor.blue:
                targetOutput = blueOutput;
                break;
            default:
                break;
        }
        
        window.RemoveObjectFromDisplay();

        if (color != box.Task.sectorColor)
        {
            targetOutput = input;
        }
       
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
