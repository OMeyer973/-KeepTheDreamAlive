using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : DoorActivator
{
    // see DoorActivator for parameters
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transporter transporter = other.GetComponent<Transporter>();
        // if colliding object is not a transporter : abort
        if (transporter == null) return;
        if (color != TransporterColor.Both && transporter.color != color) return;
        // if wrong transporter color : abort
        PressButton();        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Transporter transporter = other.GetComponent<Transporter>();
        // if colliding object is not a transporter : abort
        if (transporter == null) return;

        // if wrong transporter color : abort
        if (color != TransporterColor.Both && transporter.color != color) return;

        ReleaseButton();
    }
}
