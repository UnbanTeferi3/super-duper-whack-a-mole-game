using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKeyboard : MonoBehaviour
{
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyBoardTypeLetter(string letter)
    {
        
        inputField.text += letter;
        
        //inputField.Select();
        inputField.ActivateInputField();

        StartCoroutine(WaitForNextFrame());

        //inputField.caretPosition = inputField.text.Length;
        
    }

    public void KeyboardDelete()
    {

        inputField.text = inputField.text.Remove(inputField.text.Length - 1, 1);

        inputField.ActivateInputField();

        StartCoroutine(WaitForNextFrame());

    }

    IEnumerator WaitForNextFrame()
    {
        yield return new WaitForFixedUpdate();

        inputField.MoveTextEnd(true);//Used to make input field caret to appear!!! REMEMBER THIS

    }
        
}
