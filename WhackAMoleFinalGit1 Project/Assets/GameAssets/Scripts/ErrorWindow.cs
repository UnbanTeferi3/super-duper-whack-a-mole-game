using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorWindow : MonoBehaviour
{

    public Text errorWindowText;
    public GameObject errorWindowCloseButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ErrorWindowDefault()
    {
        if (errorWindowCloseButton.activeSelf == true)
        {
            errorWindowCloseButton.SetActive(false);
        }

        errorWindowText.text = "";

    }
}
