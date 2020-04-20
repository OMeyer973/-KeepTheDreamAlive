using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ButtonType
{
    instantaneous,
    persistant,
    wihTimer
}
public abstract class DoorActivator : MonoBehaviour
{
    // door this button will trigger
    public Door doorToTrigger;
    public TransporterColor color;
    public ButtonType buttonType;
    public float timer = 10f;

    public bool invertSignal;

    protected bool activated = false;
    private Coroutine waitAndReleaseCoroutine;
    protected void PressButton()
    {
        // button allready activated
        if (activated) return;
        activated = true;
        doorToTrigger.toggleDoorBehavior(!invertSignal);
        if (waitAndReleaseCoroutine != null)
        {
            StopCoroutine(waitAndReleaseCoroutine);
        }
        Debug.Log("button / light receiver activated !");
        // todo graphics
        // todo sound
    }
    protected void ReleaseButtonNow()
    {
        // button allready deactivated
        if (!activated) return;
        if (buttonType == ButtonType.persistant) return;

        activated = false;
        doorToTrigger.toggleDoorBehavior(invertSignal);
        Debug.Log("button / light receiver deactivated !");
        // todo graphics
        // todo sound
    }

    // release the button now or a
    protected void ReleaseButton()
    {
        if (buttonType == ButtonType.wihTimer)
        {
            waitAndReleaseCoroutine = StartCoroutine(ReleaseButtonAfterTime(timer));
        } else {
            ReleaseButtonNow();
        }
    }

    // when calling this coroutine : plug it into waitAndReleaseCoroutine !!
    // like so :
    // waitAndReleaseCoroutine = StartCoroutine (ReleaseButtonAfterTime (timer));
    private IEnumerator ReleaseButtonAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        ReleaseButtonNow();
    }
}
