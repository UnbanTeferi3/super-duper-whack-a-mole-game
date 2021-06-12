using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{
    public GameObject imgGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickToggleImage()
    {
        if (imgGO.GetComponent<Image>().isActiveAndEnabled == false)
        {
            imgGO.GetComponent<Image>().enabled = true;
        }
        else if (imgGO.GetComponent<Image>().isActiveAndEnabled == true)
        {
            imgGO.GetComponent<Image>().enabled = false;
        }

    }

    public void OnClickToggleButton()
    {
        if (imgGO.GetComponent<Button>().isActiveAndEnabled == false)
        {
            imgGO.GetComponent<Button>().enabled = true;
        }
        else if (imgGO.GetComponent<Button>().isActiveAndEnabled == true)
        {
            imgGO.GetComponent<Button>().enabled = false;
        }

    }
}
