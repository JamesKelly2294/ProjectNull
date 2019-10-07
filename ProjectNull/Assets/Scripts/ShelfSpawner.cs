using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfSpawner : MonoBehaviour
{
    public PackableItem objectToSpawnPrefab;

    public List<GameObject> currentObjects;

    public int numberOfRequiredItems = 1;

    public float cooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        cooldown = Mathf.Max(0, cooldown - 0.1f);
        if (cooldown == 0 && currentObjects.Count < numberOfRequiredItems) {
            Instantiate(objectToSpawnPrefab, transform.position, Quaternion.identity);
            cooldown = 5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PackableItem>() != null) {
            currentObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PackableItem>() != null) {
            currentObjects.Remove(other.gameObject);
        }
    }
}
