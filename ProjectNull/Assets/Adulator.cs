using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum AdulatorButton
{
    DoinGreat = 0,
    YoureTrash,
    AwesomeWork,
    KillingIt
}

public class Adulator : Machine
{
    public MachineIO output;

    TextMeshPro rulesDescription;
    AdulatorButton chosenAdulation;

    public void DoinGreatButtonWasPressed()
    {
        chosenAdulation = AdulatorButton.DoinGreat;
        ValidateBox();
    }

    public void YoureTrashButtonWasPressed()
    {
        chosenAdulation = AdulatorButton.YoureTrash;
        ValidateBox();
    }

    public void AwesomeWorkButtonWasPressed()
    {
        chosenAdulation = AdulatorButton.AwesomeWork;
        ValidateBox();
    }

    public void KillingItButtonWasPressed()
    {
        chosenAdulation = AdulatorButton.KillingIt;
        ValidateBox();
    }

    // Start is called before the first frame update
    void Start()
    {
        rulesDescription = transform.Find("Da Rulz").Find("Description").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        rulesDescription.text = "FUCK";
    }

    public override void ValidateBox()
    {
        base.ValidateBox();

        targetOutput = output;
    }
}
