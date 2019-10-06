using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = Camera.main;
    }

    private void handleGameInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hitInfo, 4, 1 << 9))
            {
                Rigidbody rb = hitInfo.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Box b = rb.GetComponent<Box>();
                    b.open = !b.open;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        handleGameInteraction();
    }
}
