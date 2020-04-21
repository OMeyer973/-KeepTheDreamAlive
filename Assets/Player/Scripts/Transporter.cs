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
    public AudioSource holeFallSFX;

    private void Start()
    {
        transporterUI = transform.GetChild(0).gameObject;
        transporterUI.SetActive(false);
        holeFallSFX = GetComponent<AudioSource>();
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
        if (holeFallSFX != null)
        {
            holeFallSFX.PlayOneShot(holeFallSFX.clip);
        }
        Game.Instance.LoseLevel(LoseCondition.FellInHole);
        gameObject.SetActive(false);
    }
}
