using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonType
{
    instantaneous,
    persistant,
    wihTimer
}
public class Button : MonoBehaviour
{
    // door this button will trigger
    public Door doorToTrigger;
    public TransporterColor color;
    public ButtonType buttonType;
    public float timer = 10f;

    public bool invertSignal;

    private bool activated = false;

    private void PressButton()
    {
        // button allready activated
        if (activated) return;
        activated = true;
        doorToTrigger.toggleDoorBehavior(!invertSignal);
    }
    private void ReleaseButton()
    {
        // button allready deactivated
        if (!activated) return;
        if (buttonType == ButtonType.persistant) return;

        activated = false;
        doorToTrigger.toggleDoorBehavior(invertSignal);
    }
    private IEnumerator ReleaseButtonAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ReleaseButton();
    }
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

        if (buttonType == ButtonType.wihTimer)
        {
            StartCoroutine(ReleaseButtonAfterTime(timer));
            return;
        }

        ReleaseButton();
    }

}
