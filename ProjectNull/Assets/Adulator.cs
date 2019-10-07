using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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

    public bool IsValidatedForBlue()
    {
        var items = box.Task.packedItems;

        if (items.Count % 2 == 1)
        {
            return chosenAdulation == AdulatorButton.DoinGreat;
        }
        else if ((items.Contains(ItemType.baseball) && !items.Contains(ItemType.basketball))
          || (items.Contains(ItemType.basketball) && !items.Contains(ItemType.baseball)))
        {
            return chosenAdulation == AdulatorButton.KillingIt;
        }
        else if (items.Contains(ItemType.baseball) && items.Contains(ItemType.basketball))
        {
            return chosenAdulation == AdulatorButton.YoureTrash;
        }
        else
        {
            return chosenAdulation == AdulatorButton.AwesomeWork;
        }
    }

    public bool IsValidatedForGreen()
    {
        var items = box.Task.packedItems;

        var count = items
            .GroupBy(e => e)
            .Where(e => e.Count() == 2)
            .Select(e => e.First());

        bool twinBoyes = count.Count() > 0;

        if (twinBoyes)
        {
            return chosenAdulation == AdulatorButton.AwesomeWork;
        }
        else if (items.Contains(ItemType.portraits) || items.Contains(ItemType.videoGame) || items.Contains(ItemType.truck))
        {
            return chosenAdulation == AdulatorButton.DoinGreat;
        }
        else if (items.Contains(ItemType.pens) && !(items.Contains(ItemType.meat) || items.Contains(ItemType.fish)))
        {
            return chosenAdulation == AdulatorButton.KillingIt;
        }
        else
        {
            return chosenAdulation == AdulatorButton.YoureTrash;
        }
    }

    public bool IsValidatedForRed()
    {
        var items = box.Task.packedItems;

        var count = items
            .GroupBy(e => e)
            .Where(e => e.Count() >= 1)
            .Select(e => e.First());

        bool uniqueBoyes = count.Count() == 0;

        if (uniqueBoyes)
        {
            return chosenAdulation == AdulatorButton.YoureTrash;
        }
        else if (items.Contains(ItemType.coins) && !items.Contains(ItemType.truck))
        {
            return chosenAdulation == AdulatorButton.AwesomeWork;
        }
        else if (items.Contains(ItemType.fish) && items.Contains(ItemType.meat))
        {
            return chosenAdulation == AdulatorButton.DoinGreat;
        }
        else
        {
            return chosenAdulation == AdulatorButton.KillingIt;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rulesDescription = transform.Find("Da Rulz").Find("Description").GetComponent<TextMeshPro>();
        rulesDescription.text = "";
        switch (color)
        {
            case ConveyorSectorColor.red:
                rulesDescription.text += "1) If box has no duplicate items - You're trash.\n\n";
                rulesDescription.text += "2) If box has coins and not a truck - Awesome work!\n\n";
                rulesDescription.text += "3) If box has fish and meat - Doin' great!\n\n";
                rulesDescription.text += "4) Otherwise - Killing it!\n";
                break;
            case ConveyorSectorColor.green:
                rulesDescription.text += "1) If box has exactly two of the same type - Awesome work!\n\n";
                rulesDescription.text += "2) If box has portrait, video game, or truck - Doin' great!\n\n";
                rulesDescription.text += "3) If box has pen but not meat and not fish - Killing it!\n\n";
                rulesDescription.text += "4) Otherwise - You're trash!\n";
                break;
            case ConveyorSectorColor.blue:
                rulesDescription.text += "1) If # of items is odd - Doin' great!\n\n";
                rulesDescription.text += "2) If box has only one type of ball in it - Killing it!\n\n";
                rulesDescription.text += "3) If box has multiple types of ball in it - You're trash.\n\n";
                rulesDescription.text += "4) Otherwise - Awesome work!\n";
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ValidateBox()
    {
        base.ValidateBox();

        bool isValidated = false;
        switch (box.Task.sectorColor)
        {
            case ConveyorSectorColor.red:
                isValidated = IsValidatedForRed();
                break;
            case ConveyorSectorColor.green:
                isValidated = IsValidatedForGreen();
                break;
            case ConveyorSectorColor.blue:
                isValidated = IsValidatedForBlue();
                break;
            default:
                break;
        }

        if(isValidated)
        {
            box.Task.Adulated = true;
            targetOutput = output;
        } else
        {
            targetOutput = rejectOutput;
        }

    }
}
