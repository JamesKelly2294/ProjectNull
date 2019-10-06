﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLabel : MonoBehaviour
{

    public List<GameObject> requiresStickerSlots;

    public List<GameObject> specialHandlingStickerSlots;

    public Task task;

    // Start is called before the first frame update
    void Start()
    {
        task.label = this;
        UpdateLabel();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void UpdateLabel()
    {

        // Update the requires section.

        foreach (var obj in requiresStickerSlots) {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }

        for (var i = 0; i < task.requiresItems.Count && i < requiresStickerSlots.Count; i++) {
            var obj = requiresStickerSlots[i];
            obj.GetComponent<MeshRenderer>().enabled = true;
            obj.GetComponent<MeshRenderer>().material = task.GetImageForItem(task.requiresItems[i]);
        }


        // Update the special handling secition

        foreach (var obj in specialHandlingStickerSlots) {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }

        for (var i = 0; i < task.requiresSteps.Count && i < specialHandlingStickerSlots.Count; i++) {
            var obj = specialHandlingStickerSlots[i];
            obj.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}