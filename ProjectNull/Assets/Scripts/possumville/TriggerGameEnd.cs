using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameEnd : MonoBehaviour
{
    private bool _wasTriggered;
    public bool WasTriggered()
    {
        return _wasTriggered;
    }

    public GameEndType GameEndType;

    // Start is called before the first frame update
    void Start()
    {
        _wasTriggered = false;
    }

    void OnTriggerEnter(Collider other)
    {
        _wasTriggered = true;
    }
}
