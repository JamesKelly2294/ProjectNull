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
    
    public List<Step> steps;

    public float timeLeft;

    public bool hasBegun;

    public bool hasFinished;

}

[System.Serializable]
public struct Step
{
    public StepType StepType;

    public ItemType item;

    public bool completed;
}


public enum StepType {
    placeShippingLabel,
    fillBox,
    emptyBox,
    wetBox,
    dryBox,
    freezeBox,
    heatBox
}

public enum ItemType {
    none,

    fish,

    meat,

    baseball,

    basketball,

    toyTruck,

    sharpie,

    coins,

    pictureFrame,

    videoGame
}