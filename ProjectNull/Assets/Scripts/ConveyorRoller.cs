using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorRoller : MonoBehaviour
{

    public GameObject roller;

    public List<GameObject> currentObjects;

    public float speed = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed == 0) {
            return;
        }

        var rollerSpeed = 4 * 360 * speed;
        roller.transform.localEulerAngles += new Vector3(0, -rollerSpeed * Time.deltaTime, 0);

        var dir = transform.TransformVector(new Vector3(speed * Time.deltaTime, 0, 0));
        foreach (var obj in currentObjects) {
            obj.transform.Translate(obj.transform.InverseTransformVector(dir));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Box>() != null) {
            currentObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        currentObjects.Remove(other.gameObject);
    }
}
