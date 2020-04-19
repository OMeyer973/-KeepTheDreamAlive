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

    public void TypeText(string message, float speed = .02f)
    {
        textField = GetComponent<Text>();
        textField.text = "";
        StartCoroutine(TypeTextCoroutine(textField, message, speed));
    }

    private IEnumerator TypeTextCoroutine(Text text, string textText, float timePause)
    {
        for (int i = 0; i < textText.Length; i++)
        {
            text.text += textText[i];

            yield return 0;
            yield return new WaitForSeconds(timePause);
        }
    }

}