using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnVentController : MonoBehaviour
{

    public GameObject point;

    public GameObject boxPrefab;

    public float timeBetweenSpawns = 20f;

    public float numberOfItemsToPack = 0f;

    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime <= 0) {
            currentTime = timeBetweenSpawns;

            var gameObject = Instantiate(boxPrefab, point.transform.position, Quaternion.identity);
            var numberOfItems = Mathf.Max(Mathf.Min(numberOfItemsToPack, 18), 0);

            
            var allItems = new List<ItemType> { ItemType.baseball, ItemType.basketball, ItemType.coins, ItemType.fish, ItemType.meat, ItemType.pens, ItemType.portraits, ItemType.truck, ItemType.videoGame };
            var items = new List<ItemType>();
            for (var i = 0; i < numberOfItems; i ++) {
                var randItemId = Random.Range(0, 1000) % allItems.Count;
                items.Add(allItems[randItemId]);
            }


            var allSectorColors = new List<ConveyorSectorColor> { ConveyorSectorColor.blue, ConveyorSectorColor.green, ConveyorSectorColor.red };
            var randColorId = Random.Range(0, 1000) % allSectorColors.Count;
            var sectorColor = allSectorColors[randColorId];
            
            var box = gameObject.GetComponent<Box>();
            var label = box.boxLabel.GetComponent<BoxLabel>();
            label.task.requiresItems = items;
            label.task.sectorColor = sectorColor;
            label.UpdateLabel();
        }

    }
}
