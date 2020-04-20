using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMirror : MonoBehaviour
{
    private int currHitPoints;

    public float minTimeBetweenDamage = 1;
    private bool canTakeDamage = true;

    public AudioSource damageSound;
    public AudioSource brokenSound;

    // Start is called before the first frame update
    void Start()
    {
        currHitPoints = Game.Instance.mirrorMaxHp;
        Debug.Log("Game.Instance.mirrorMaxHp " + Game.Instance.mirrorMaxHp);
        Debug.Log("currHitPoints " + currHitPoints);

    }

    private void TakeDamage()
    {
        currHitPoints--;
        UI.Instance.UpdateMirrorUI(currHitPoints);
        damageSound.PlayOneShot(damageSound.clip);
        if (currHitPoints <= 0)
        {
            brokenSound.PlayOneShot(brokenSound.clip);
            Game.Instance.LoseLevel(LoseCondition.HitWall);
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
