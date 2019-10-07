using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HintTrigger : MonoBehaviour
{
    public Hint Hint;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hint Triggered");
        Hint.IsDisplayable = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Hint Detriggered");
        Hint.IsDisplayable = false;
        Hint.IsPresenting = false;
    }
}
