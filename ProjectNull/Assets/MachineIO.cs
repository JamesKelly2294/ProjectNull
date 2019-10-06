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
        if (machine.canAccept && colliders.Count > 0)
        {
            Debug.Log("Schloink");
            machine.canAccept = false;
            capturedObject = colliders[0].gameObject;
            StartCoroutine(SchloinkObject(capturedObject.transform.position, capturedObject.transform.position + distanceOfTransit * axisOfTransit, distanceOfTransit / speed));
        }
    }

    private int capturedObjectLayer;
    private const int shloinkedLayer = 12;
    IEnumerator SchloinkObject(Vector3 originalPosition, Vector3 finalPosition, float duration)
    {
        capturedObjectLayer = capturedObject.layer;
        capturedObject.layer = shloinkedLayer;
        capturedObject.GetComponent<Rigidbody>().isKinematic = true;
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
            capturedObject.layer = capturedObjectLayer;
        }

        machine.ObjectWasSchloinked(capturedObject);
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
