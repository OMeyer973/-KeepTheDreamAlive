using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Button : MonoBehaviour
{
    // door this button will trigger
    public Door doorToTrigger;
    public TransporterColor color;
    public bool stayActivated;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Transporter transporter = other.GetComponent<Transporter>();
        // if colliding object is not a transporter : abort
        if (transporter == null) return;
        // if wrong transporter color : abort
        if (color != TransporterColor.Both && transporter.color != color) return; 

        doorToTrigger.toggleDoorBehavior(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Transporter transporter = other.GetComponent<Transporter>();
        // if colliding object is not a transporter : abort
        if (stayActivated) return;
        if (transporter == null) return;
        // if wrong transporter color : abort
        if (color != TransporterColor.Both && transporter.color != color) return;

        doorToTrigger.toggleDoorBehavior(false);
    }
}
