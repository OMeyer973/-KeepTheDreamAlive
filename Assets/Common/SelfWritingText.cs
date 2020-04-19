using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ? 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net

//Writes text letter by letter with time step

public class SelfWritingText : MonoBehaviour
{ 
    [SerializeField] private float letterPause = 0.1f;
    private Text textField;

    public void TypeText(string message)
    {
        textField = GetComponent<Text>();
        textField.text = "";
        StartCoroutine(TypeTextCoroutine(textField, message, letterPause));
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