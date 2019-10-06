using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{

    public List<GameObject> rollers;
    float rollerRotation = 0f;
    float rollerSpeed = 180f;

    [Range(0.01f, 1f)]
    float speed = 0.25f;
    public GameObject detector;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // rollerRotation = (rollerRotation + (rollerSpeed * Time.deltaTime)) % 1f;
        foreach (var i in rollers) {
            // i.transform.localRotation.SetAxisAngle(new Vector3(1,0,0), rollerRotation);
            i.transform.localRotation *= Quaternion.Euler(Vector3.down * rollerSpeed * Time.deltaTime);
        }

        var dir = transform.TransformVector(new Vector3(speed * Time.deltaTime, 0, 0));
        var detectorBounds = detector.GetComponent<BoxCollider>().bounds;
        foreach (GameObject obj in GetObjectsInLayer(9)) {
            if (obj.GetComponent<Box>() != null && detectorBounds.Intersects(obj.GetComponent<BoxCollider>().bounds)) {
                
                obj.transform.Translate(obj.transform.InverseTransformVector(dir));


            }
        }
    }

    private static List<GameObject> GetObjectsInLayer(int layer) {
        var ret = new List<GameObject>();
        foreach (GameObject o in (FindObjectsOfType(typeof(GameObject)) as GameObject[]))
        {
            if (o.layer == layer)
            {
                ret.Add (o);
            }
        }
        return ret;        
    }
}
