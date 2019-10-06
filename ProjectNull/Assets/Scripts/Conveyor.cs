using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{

    public List<ConveyorRoller> rollers;

    public ConveyorSectorColor sectorColor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var sector = GameObject.FindObjectOfType<ConveyorManager>().SectorForColor(sectorColor);
        var speed = sector.Value.speed;

        foreach(var roller in rollers) {
            roller.speed = speed;
        }

    }
}
