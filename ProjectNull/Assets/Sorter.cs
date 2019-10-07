using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorter : Machine
{

    public MachineIO input;
    public MachineIO redOutput;
    public MachineIO greenOutput;
    public MachineIO blueOutput;
    public MachineIO failureOutput;

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

    private void ValidateBox(ConveyorSectorColor color)
    {
        window.RemoveObjectFromDisplay();
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
