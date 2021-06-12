using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleTimer : MonoBehaviour
{
    public Text timer;
    public Text timerComboText;
    
    public AudioSource aS;
    //public TextMesh timer;
    //public float minutes = 5f;
    public float seconds = 30f;
    public float miliseconds = 0;

    public bool allowedToStart = false;

    public GameObject[] endGameGOs = new GameObject[2];
    public GameObject scoreGO;
    public HammerColliderManager hammerCollider;
    public SpawnMoleList spawnMoleList;

    public AudioClipsManager bgAudioClipsManager;
    //public MoleBehaviour moleBehaviour;

    

    /*
    //events/delegates
    public delegate void OnMoleTimer60EventHandler();
    public static event OnMoleTimer60EventHandler OnMoleTimer60;

    public delegate void OnMoleTimer100EventHandler();
    public static event OnMoleTimer100EventHandler OnMoleTimer100;
    */


    void OnEnable()
    {

        CountdownBehaviour.OnFinishCountDown += AllowTimerStart;

    }

    void OnDisable()
    {

        CountdownBehaviour.OnFinishCountDown -= AllowTimerStart;

    }

    void Start()
    {
        //timer.text = "60";
        //timer.gameObject.GetComponent<Text>().color = Color.white;
        //timer.gameObject.GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    void Update()
    {
        if(allowedToStart == true)
        {

            RunTimer();
        }

        //BroadcastTimerEvents();

        //CountDown10Sec();
        ChangeTimerTextColor();


    }

    public void AllowTimerStart()
    {
        if (allowedToStart != true)
        {
            allowedToStart = true;

        }


    }

    public void EnableAllEndGameGO()
    {
        foreach(GameObject i in endGameGOs)
        {
            if(i.activeSelf == false)
            {

                i.SetActive(true);

            }

        }


    }

    public void ChangeTimerTextColor()
    {
        if(seconds <= 10)
        {

            if (timer.color != Color.red)
            {

                timer.color = Color.red;
            }
        }
        else
        {
            if (timer.color != Color.black)
            {

                timer.color = Color.black;
            }
        }
        

        
    }

    public void CountDown10Sec()
    {
     
        for (int i = 11; i >= 0; i--)
        {

            if (seconds == i)
            {
                aS.Play();
                Debug.Log("Timer audio clip played");

            }

        }

    }       
        
    

    /*
    public void BroadcastTimerEvents()
    {

        if(seconds == 60f)
        {
            OnMoleTimer60?.Invoke();

        }
        else if(seconds == 100)
        {
            OnMoleTimer100?.Invoke();
        }




    }
    */

    public void RunTimer()
    {

        if (timer.color != Color.black)
        {

            timer.color = Color.black;
        }

        if (seconds >= 0)
        {

            if (miliseconds <= 0)
            {

                seconds--;

                if(miliseconds <=0 && seconds <= 10)
                {
                    
                    CountDown10Sec();
                }                          

                miliseconds = 100;
            }

            miliseconds -= Time.deltaTime * 100;

            //timer.text = "TIME: " + seconds.ToString();
            timer.text = $"{seconds.ToString()}";
            //timer.text = "TIME: " + string.Format("{0}:{1}", minutes, seconds);

        }

        else
        {
            timer.text = "0";
            bgAudioClipsManager.StopAudioSourceClip(1);
            EnableAllEndGameGO();
            scoreGO.GetComponent<MoleScore>().enabled = false;
            hammerCollider.colliderAllowed = false;
            spawnMoleList.DisableAllSpawnMole();
            //panelManager.ChangePanels();
            //panelManager.DisableMainGameGO();
            //this.gameObject.GetComponent<PanelManager>().ChangePanels();
        }

        /*
        //For increasing difficulty as time goes on
        if (seconds >= 60)
        {
            if(moleBehaviour.cryProbabilityThreshold != 0.5f)
            {

                moleBehaviour.cryProbabilityThreshold = 0.5f ;

            }

        }
        else if (seconds >= 100)
        {
            if (moleBehaviour.cryProbabilityThreshold != 0.25f)
            {

                moleBehaviour.cryProbabilityThreshold = 0.25f;

            }

        }
        */

    }


}

