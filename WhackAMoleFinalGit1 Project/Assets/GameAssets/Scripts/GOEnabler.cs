using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOEnabler : MonoBehaviour
{
    public GameObject gO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableGO()
    {
        if (gO.activeSelf == false)
        {
            gO.SetActive(true);
        }

    }

    public void DisableGO()
    {
        if (gO.activeSelf == true)
        {
            gO.SetActive(false);
        }

    }

    public void EnableOrDisableGO()
    {
        if (gO.activeSelf == false)
        {
            gO.SetActive(true);
        }
        else if (gO.activeSelf == true)
        {
            gO.SetActive(false);
        }

    }
}
