using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private Collider2D doorCollider;
    private Renderer doorRenderer;

    public bool closedByDefault = true;

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
            doorCollider.enabled = !closedByDefault;
            doorRenderer.enabled = !closedByDefault;
        }
        if (!enter) // exit
        {
            doorCollider.enabled = closedByDefault;
            doorRenderer.enabled = closedByDefault;
        }
    }

}
