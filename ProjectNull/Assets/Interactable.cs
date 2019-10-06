using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    Box = 0,
    Button = 1,
}

public class Interactable : MonoBehaviour
{
    public InteractableType type;

    public void Interact()
    {
        switch(type)
        {
            case InteractableType.Box:
                transform.GetComponent<Box>().open = !transform.GetComponent<Box>().open;
                break;
            case InteractableType.Button:
                transform.parent.GetComponent<WorldButton>().Press();
                break;
            default:
                break;
        }
    }
}
