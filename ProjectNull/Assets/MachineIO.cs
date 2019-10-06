using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineIO : MonoBehaviour
{
    public bool canAccept = true;
    public BoxCollider voidRigidbody;

    private Vector3 axisOfTransit = Vector3.forward;
    private float distanceOfTransit = 3.0f;
    private float speed = 2.0f;
    private GameObject capturedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAccept && colliders.Count > 0)
        {
            Debug.Log("Schloink");
            canAccept = false;
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
            canAccept = true;
        }

        capturedObject = null;
    }

    private List<Collider> colliders = new List<Collider>();
    public List<Collider> GetColliders() { return colliders; }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<Box>()) { return; }
        if (!colliders.Contains(other)) { colliders.Add(other); }
        Debug.Log("OnTriggerEnter " + other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.GetComponent<Box>()) { return; }
        colliders.Remove(other);
        Debug.Log("OnTriggerExit " + other);
    }

}
