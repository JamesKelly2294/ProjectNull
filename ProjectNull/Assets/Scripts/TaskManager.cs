using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{

    public List<Task> tasks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public struct Task {
    
    public BoxLabel label;

    public List<ItemType> requiresItems;
    public List<ItemType> completedItems;

    public List<StepType> requiresSteps;
    public List<StepType> completedSteps;

    public float timeLeft;

    public bool hasBegun;

    public bool hasFinished;


    static Dictionary<ItemType, Material> itemMaterials = new Dictionary<ItemType, Material>();
    public Material GetImageForItem(ItemType item) {
        if (itemMaterials.ContainsKey(item)) {
            return itemMaterials[item];
        }

        string name = "";
        switch (item) {
            case ItemType.baseball:
                name = "baseball"; break;
            case ItemType.basketball:
                name = "basketball"; break;
            case ItemType.coins:
                name = "coins"; break;
            case ItemType.fish:
                name = "fish"; break;
            case ItemType.meat:
                name = "meat"; break;
            case ItemType.pens:
                name = "pens"; break;
            case ItemType.portraits:
                name = "portraits"; break;
            case ItemType.truck:
                name = "truck"; break;
            case ItemType.videoGame:
                name = "videoGame"; break;
        }

        string url = "Stickers/Items/" + name;
        var resource =  Resources.Load<Material>(url);
        itemMaterials[item] = resource;
        return resource;
    }

}

public enum StepType {
    placeShippingLabel,
    wetBox,
    dryBox,
    freezeBox,
    heatBox
}

public enum ItemType {
    fish,

    meat,

    baseball,

    basketball,

    truck,

    pens,

    coins,

    portraits,

    videoGame
}