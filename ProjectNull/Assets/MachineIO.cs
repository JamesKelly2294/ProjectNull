using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MachineIOType
{
    Input = 0,
    Output = 1,
    InputOutput = 2
}

public class MachineIO : MonoBehaviour
{
    public MachineIOType type;
    public Machine machine;
    
    private BoxCollider voidRigidbody;

    private Vector3 axisOfTransit = Vector3.forward;
    private Vector3 axisOfOutput = Vector3.right;
    private float distanceOfTransit = 3.0f;
    private float speed = 2.0f;
    private GameObject capturedObject;

    // Start is called before the first frame update
    void Start()
    {
        voidRigidbody = transform.Find("Void").GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == MachineIOType.Input && machine.canAccept && colliders.Count > 0)
        {
            Debug.Log("Schloink");
            machine.canAccept = false;
            SchloinkObject(colliders[0].gameObject);
        }
    }

    public void SchloinkObject(GameObject obj)
    {
        capturedObject = obj;
        capturedObject.GetComponent<Rigidbody>().isKinematic = true;
        StartCoroutine(SchloinkAnimation(capturedObject.transform.position, capturedObject.transform.position + distanceOfTransit * axisOfTransit, distanceOfTransit / speed));
    }

    public void SchlorpObject()
    {
        StartCoroutine(SchloinkAnimation(voidRigidbody.transform.position + axisOfOutput * (distanceOfTransit / 1.5f), voidRigidbody.transform.position - axisOfOutput * (distanceOfTransit / 1.5f), distanceOfTransit / speed));
    }

    IEnumerator SchloinkAnimation(Vector3 originalPosition, Vector3 finalPosition, float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            capturedObject.transform.position = originalPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;

                capturedObject.transform.position = Vector3.Lerp(originalPosition, finalPosition, progress);
                yield return null;
            }
        }

        if (capturedObject)
        {
            capturedObject.transform.position = finalPosition;
        }

        machine.ObjectWasSchloinked(capturedObject);
        capturedObject = null;
    }

    IEnumerator SchlorpAnimation(Vector3 originalPosition, Vector3 finalPosition, float duration)
    {
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            capturedObject.transform.position = originalPosition;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;

                capturedObject.transform.position = Vector3.Lerp(originalPosition, finalPosition, progress);
                yield return null;
            }
        }

        if (capturedObject)
        {
            capturedObject.transform.position = finalPosition;
        }

        capturedObject.GetComponent<Rigidbody>().isKinematic = false;
        machine.ObjectWasSchlorped(capturedObject);
        capturedObject = null;
    }

    private List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders() { return colliders; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Box>()) { return; }
        if (!colliders.Contains(other)) { colliders.Add(other); }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Box>()) { return; }
        colliders.Remove(other);
    }

}
