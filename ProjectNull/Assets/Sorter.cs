using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : Machine
{

    public MachineIO input;
    public MachineIO redOutput;
    public MachineIO greenOutput;
    public MachineIO blueOutput;

    private ConveyorSectorColor pressedColor;

    public void RedButtonWasPressed()
    {
        pressedColor = ConveyorSectorColor.red;
        ValidateBox();
    }

    public void GreenButtonWasPressed()
    {
        pressedColor = ConveyorSectorColor.green;
        ValidateBox();
    }

    public void BlueButtonWasPressed()
    {
        pressedColor = ConveyorSectorColor.blue;
        ValidateBox();
    }

    public override void ValidateBox()
    {
        base.ValidateBox();
        switch (pressedColor)
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

        if (pressedColor != box.Task.sectorColor)
        {
            targetOutput = input;
        }
    }

    public override void BoxAccepted(Box box)
    {
        base.BoxAccepted(box);

        box.MarkAsSorted();
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
