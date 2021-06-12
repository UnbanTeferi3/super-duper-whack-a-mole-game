using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject currentPanel;
    public GameObject nextPanel;
    public GameObject mainGameGO;
    public List<GameObject> panelList;
    

    //public GameObject singletonObject;
    //public GameObject gamePanel1;
    //public GameObject gamePanel2;

    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisablePanelList()
    {

        if(panelList.Count != 0)
        {
            foreach(GameObject i in panelList)
            {
                if (i.activeSelf == true)
                {
                    i.SetActive(false);

                }
                

            }


        }

    }

    public void EnablePanelList()
    {

        if (panelList.Count != 0)
        {
            foreach (GameObject i in panelList)
            {
                if (i.activeSelf == false)
                {
                    i.SetActive(true);

                }


            }


        }

    }

    public void ChangePanels()
    {
        currentPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void DisableMainGameGO()
    {

        if (mainGameGO.activeSelf == true)
        {
            mainGameGO.SetActive(false);

        }
        


    }

    public void EnableMainGameGO()
    {

        if (mainGameGO.activeSelf == false)
        {
            mainGameGO.SetActive(true);

        }



    }
    /*
    public void LoadGamePanel()
    {
        currentPanel.SetActive(false);

        if (ScrabbleSingleton.SS.gameCount % 2 != 0)
        {

            gamePanel1.SetActive(true);
            ScrabbleSingleton.SS.gameCount += 1;

        }
        else if (ScrabbleSingleton.SS.gameCount % 2 == 0)
        {

            gamePanel2.SetActive(true);
            ScrabbleSingleton.SS.gameCount += 1;
        }

    }
    */
}
