using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Borrows from https://answers.unity.com/questions/12322/drag-gameobject-with-mouse.html
[RequireComponent(typeof(Rigidbody))]
public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        var mouseVector = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(mouseVector);
    }

    void OnMouseDrag()
    {
        var currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        var currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentPosition;
    }
}
