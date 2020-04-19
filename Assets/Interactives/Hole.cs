using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Transporter transporter = other.GetComponent<Transporter>();
        // if colliding object is not a transporter : abort
        if (transporter == null)
        {
            Debug.Log("something weird felt into a hole");
            return;
        }
        Game.Instance.LoseLevel(LoseCondition.FellInHole);
    }
}
