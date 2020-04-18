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

        doorCollider.enabled = closedByDefault;
        doorRenderer.enabled = closedByDefault;
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
            doorCollider.enabled = !closedByDefault;
            doorRenderer.enabled = !closedByDefault;
        } else { // at least one button is activation the door
            doorCollider.enabled = closedByDefault;
            doorRenderer.enabled = closedByDefault;
        }

    }

}
