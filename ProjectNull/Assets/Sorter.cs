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
        window.RemoveObjectFromDisplay();
    }

    public void GreenButtonWasPressed()
    {
        window.RemoveObjectFromDisplay();
    }

    public void BlueButtonWasPressed()
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
