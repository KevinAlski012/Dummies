using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Interactor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Debug.Log("Enter");
        var interactable = other.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            // interactable.Focused(this);
            interactable.Act(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        // Debug.Log("Exit");
        var interactable = other.GetComponentInParent<IInteractable>();
        if (interactable != null)
        {
            // interactable.UnFocused(this);
        }
    }
}
