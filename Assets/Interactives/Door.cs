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
    public DoorType doorType;
    public bool closedByDefault = true;

    public int numberOfSignalsToActivate = 1;
    private int activators;

    [Header("gameobjects a activer pour afficher l'état enclenché ou non du bouton")]

    [Header("! doit être différent du gameobject qui porte ce script ! (un de ses enfant par exemple)")]

    public GameObject closedDoor;
    public GameObject openDoor;

    private void Start()
    {
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
        closedDoor.SetActive(closedByDefault);
        openDoor.SetActive(!closedByDefault);
    }

    // activate the door (ie positive signal incoming)
    private void ActivateDoor()
    {

        closedDoor.SetActive(!closedByDefault);
        openDoor.SetActive(closedByDefault);
    }

    private void DeactivateDoor()
    {
        // if persistant : never deactivated
        if (doorType == DoorType.persistant) return;

        closedDoor.SetActive(closedByDefault);
        openDoor.SetActive(!closedByDefault);
    }

}
