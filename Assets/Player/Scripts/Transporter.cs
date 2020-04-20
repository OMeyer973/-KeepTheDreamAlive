using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransporterColor
{
    Red, Blue, Both
}
public class Transporter : MonoBehaviour
{
    public TransporterColor color;
    private GameObject transporterUI;
    private AudioSource holeFallSFX;

    private void Start()
    {
        transporterUI = transform.GetChild(0).gameObject;
        transporterUI.SetActive(false);
    }
    public void BeginSteering()
    {
        transporterUI.SetActive(true);
    }

    public void EndSteering()
    {
        transporterUI.SetActive(false);
    }

    public void FallInHole()
    {
        holeFallSFX.PlayOneShot(holeFallSFX.clip);
        Game.Instance.LoseLevel(LoseCondition.FellInHole);
        gameObject.SetActive(false);
    }
}
