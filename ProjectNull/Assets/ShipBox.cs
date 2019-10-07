using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBox : MonoBehaviour
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
        Box b = other.GetComponent<Box>();

        if(b && b.Task.Complete)
        {
            if(GameManager.Instance.GrabIt.GrabbedObject == b.gameObject)
            {
                GameManager.Instance.GrabIt.ReleaseGrabbed();
            }
            GameManager.Instance.IncrementScore();

            Destroy(b.gameObject);
        }
    }
}
