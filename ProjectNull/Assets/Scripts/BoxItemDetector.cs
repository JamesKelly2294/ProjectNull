using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxItemDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ConsiderPacking(other);
    }

    private void OnTriggerStay(Collider other) {
        ConsiderPacking(other);
    }

    public void ConsiderPacking(Collider other) {
        var box = GetComponentInParent<Box>();
        if (!box.open) {
            return;
        }

        if (other.gameObject.GetComponent<PackableItem>() != null) {
            var packedItem = other.gameObject.GetComponent<PackableItem>();
            var label = box.boxLabel.GetComponent<BoxLabel>();
        
            var numberOfItemsOfThisTypeNeeded = 0;
            foreach (var item in label.task.requiresItems) {
                if (item == packedItem.itemType) {
                    numberOfItemsOfThisTypeNeeded += 1;
                }
            }

            foreach (var item in label.task.packedItems) {
                if (item == packedItem.itemType) {
                    numberOfItemsOfThisTypeNeeded -= 1;
                }
            }

            if (numberOfItemsOfThisTypeNeeded > 0) { 
                label.task.packedItems.Add(packedItem.itemType);
                GameManager.Instance.GrabIt.Release(other.gameObject.GetComponent<Grabbable>());
                label.UpdateLabel();
                Destroy(other.gameObject);
            }
        }
    }
}
