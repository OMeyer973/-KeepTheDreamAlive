using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorType
{
    instantaneous,
    persistant
}

public class Door : MonoBehaviour
{

    private Collider2D doorCollider;
    private Renderer doorRenderer;

    public DoorType doorType;
    public bool closedByDefault = true;

    public int numberOfSignalsToActivate = 1;
    private int activators;

    private void Start()
    {
        doorCollider = GetComponent<Collider2D>();
        doorRenderer = GetComponent<Renderer>();

        Init();
        activators = -numberOfSignalsToActivate;
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

        if (activators < 0)
        {   // default state 
            DeactivateDoor();
        } else { // at least one button is activation the door
            ActivateDoor();
        }

    }

    // deactivate the door (ie negative signal incoming)
    private void Init()
    {
        doorCollider.enabled = closedByDefault;
        doorRenderer.enabled = closedByDefault;
    }

    // activate the door (ie positive signal incoming)
    private void ActivateDoor()
    {
        doorCollider.enabled = !closedByDefault;
        doorRenderer.enabled = !closedByDefault;
    }

    private void DeactivateDoor()
    {
        // if persistant : never deactivated
        if (doorType == DoorType.persistant) return;
        doorCollider.enabled = closedByDefault;
        doorRenderer.enabled = closedByDefault;
    }

}
