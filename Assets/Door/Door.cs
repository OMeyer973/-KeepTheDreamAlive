using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Collider2D doorCollider;
    private Renderer doorRenderer;

    public bool closedByDefault = true;

    private int activators;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorRenderer = GetComponent<Renderer>();

        DeactivateDoor();
    }

    public void toggleDoorBehavior(bool enter)
    {
        if (enter)
        {
            activators++;
        }
        if (!enter) // exit
        {
            activators--;
        }

        if (activators <= 0)
        {   // default state 
            DeactivateDoor();
        } else { // at least one button is activation the door
            ActivateDoor();
        }

    }

    // activate the door (ie positive signal incoming)
    private void ActivateDoor()
    {
        doorCollider.enabled = !closedByDefault;
        doorRenderer.enabled = !closedByDefault;
    }

    // deactivate the door (ie negative signal incoming)
    private void DeactivateDoor()
    {
        doorCollider.enabled = closedByDefault;
        doorRenderer.enabled = closedByDefault;
    }

}
