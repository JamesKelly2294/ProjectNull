using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{

    public List<ConveyorRoller> rollers;

    public List<GameObject> structure;

    public ConveyorSectorColor sectorColor;


    private ConveyorSector? sector;

    // Start is called before the first frame update
    void Start()
    {
        sector = FindObjectOfType<ConveyorManager>().SectorForColor(sectorColor);
        foreach (var obj in structure)
        {
            var mat = obj.GetComponent<MeshRenderer>().material;
            if (mat != sector.Value.material)
            {
                obj.GetComponent<MeshRenderer>().material = sector.Value.material;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        var speed = sector.Value.speed;
        
        foreach (var roller in rollers)
        {
            if(!roller)
            {
                break;
            }
            roller.speed = speed;
        }
    }
}
