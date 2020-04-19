using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public static int maxHitPoints = 3;
    private int currHitPoints = 3;

    public float minTimeBetweenDamage = 1;
    private bool canTakeDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        currHitPoints = maxHitPoints;   
    }

    private void TakeDamage()
    {
        currHitPoints--;
        Debug.Log("mirror has been hit ! only " + currHitPoints + " left");
        if (currHitPoints <= 0)
        {
            Game.Instance.LoseLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (canTakeDamage)
        {
            TakeDamage();
            canTakeDamage = false;
            StartCoroutine(WaitAndResetCanTakeDamage());
        }

    }

    IEnumerator WaitAndResetCanTakeDamage()
    {
        yield return new WaitForSeconds(minTimeBetweenDamage);
        canTakeDamage = true;
    }
}
