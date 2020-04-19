using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ? 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net

//Writes text letter by letter with time step

public class SelfWritingText : MonoBehaviour
{ 
    [SerializeField] private float letterPause = 0.02f;
    private Text textField;
    private string text;
    private float timePause = .015f;
    public void TypeText(string message, float speed = .02f)
    {
        StopCoroutine("TypeTextCoroutine");
        textField = GetComponent<Text>();
        textField.text = "";
        text = message;
        timePause = speed;
        StartCoroutine("TypeTextCoroutine");
    }
    private IEnumerator TypeTextCoroutine()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textField.text += text[i];

            yield return 0;
            yield return new WaitForSeconds(timePause);
        }
    }


}