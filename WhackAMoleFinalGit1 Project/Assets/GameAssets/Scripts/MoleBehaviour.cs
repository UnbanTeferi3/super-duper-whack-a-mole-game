using System.Collections;
using System.Collections.Generic;
using System;// remove in final version if not used
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Animations;

public class MoleBehaviour : MonoBehaviour
{
    //public delegate void OnMoleDestroyedEventHandler();
    //public static event OnMoleDestroyedEventHandler OnMoleDestroyed;
    public GameObject moleStateAnimObject;
    public GameObject molePosAnimObject;
    public float probability;
    public float cryProbability;
    public float cryProbabilityThreshold = 0.75f;
    //public float cryDelay;
    public float cryDelayLower;
    public float cryDelayUpper;
    public float endIdleDelayLower;
    public float endIdleDelayUpper;
    public bool cryAllowed;
    public bool suddenCry;
    public int moleState = 0;
    //public bool hasBeenHit = false;

    //for audio:
    public AudioSource[] aSArray = new AudioSource[6];
    public GameObject aSGO;

    //for game difficulty
    public MoleTimer moleTimer;
    public bool moleTimerReached60 = false;
    public bool moleTimerReached80 = false;

    private void OnEnable()
    {
        //MoleTimer.OnMoleTimer60 += IncreaseDifficulty;
        //MoleTimer.OnMoleTimer100 += IncreaseDifficulty;
    }

    private void OnDisable()
    {
        //MoleTimer.OnMoleTimer60 -= IncreaseDifficulty;
        //MoleTimer.OnMoleTimer100 -= IncreaseDifficulty;
    }

    private void Awake()
    {
        moleTimer = GameObject.FindGameObjectWithTag("Timer").GetComponent<MoleTimer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        suddenCry = true;
        SetProbability();
        ChangeState();
        //StartCoroutine(WaitAndChangeToCry(1.2f));
        //StartCoroutine(WaitAndChangeToCry(UnityEngine.Random.Range(cryDelayLower, cryDelayUpper)));
        StartCoroutine(WaitAndChangeToCry(UnityEngine.Random.Range(cryDelayLower, cryDelayUpper)));
        StartCoroutine(MoleIdleEnd(UnityEngine.Random.Range(endIdleDelayLower, endIdleDelayUpper)));


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (cryAllowed == true)
        {
            //StartCoroutine(WaitAndChangeToCry(UnityEngine.Random.Range(cryDelayLower, cryDelayUpper)));
            StartCoroutine(WaitAndChangeToCry(0.5f));
        }
        */
        IncreaseDifficultyWithTime();


    }

    public void DestroyMole()
    {
        //OnMoleDestroyed?.Invoke();



        this.gameObject.GetComponentInParent<SpawnMole>().spawning = false;

        Destroy(this.gameObject.transform.parent.gameObject);
        
    }

    public void SetProbability()
    {

        probability = UnityEngine.Random.Range(0f, 1f);
    }

    public void SetCryProbability()
    {

        cryProbability = UnityEngine.Random.Range(0f, 1f);
    }

    /*
    public void SetCryDelay()
    {

        cryDelay = UnityEngine.Random.Range(cryDelayLower, cryDelayUpper);

    }
    */

   
    public void MoleState(int state)
    {
        switch (state)
        {
            case 0:
                StopAllMoleAudio();
                aSArray[0].PlayDelayed(0.5f);
                moleState = 0;
                break;


            case 1:
                
                moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 1);
                StopAllMoleAudio();
                aSArray[1].PlayDelayed(0.5f);
                moleState = 1;
                break;
            case 2:
                
                //moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 2);
                molePosAnimObject.GetComponent<Animator>().Play("MolePositionUp 0");
                //aTaunt.PlayDelayed();
                moleState = 2;
                break;
            case 3:
                
                moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 3);
                StopAllMoleAudio();

                
                if (suddenCry == true)
                {
                    aSArray[3].Play();
                }
                else if (suddenCry == false)
                {
                    Instantiate(aSGO, new Vector3(0, 0, 0), Quaternion.identity);
                }
                /*
                else if (suddenCry == false)
                {
                    aSArray[5].Play();
                }
                */



                moleState = 3;
                break;
            case 4:
                
                moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 4);
                StopAllMoleAudio();
                aSArray[4].Play();
                moleState = 4;
                break;

            default :
                
                Debug.Log("Invalid input");
                break;
                   

        }



    }

    public void ChangeState()
    {
        //Can be changed to case statements

        if (probability >= 0.25f && probability < 0.5f)
        {
            //moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 1);
            MoleState(1);

        }
        else if (probability >= 0.5f && probability < 0.75f)
        {
            //moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 2);
            MoleState(2);
            StartCoroutine(WaitAndChangeToTaunt(1f));

        }
        else if (probability >= 0.75f)
        {
            //moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 3);
            MoleState(3);

        }
        else
        {

            MoleState(0);

        }

    }

    public void ChangeToCry()
    {
        cryAllowed = false;
        SetCryProbability();
        if (cryProbability >= cryProbabilityThreshold)
        {
            /*
            if(moleStateAnimObject.GetComponent<Animator>().GetInteger("AnimState") != 3)
            {
                moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 3);
            }
            */

            if(moleState != 3 && moleState != 2)
            {
                
                MoleState(3);
                molePosAnimObject.GetComponent<Animator>().Play("MolePositionJump");


            }
            

        }

    }



    private IEnumerator WaitAndChangeToCry(float waitTime)
    {
        
        //spawning = true;
        yield return new WaitForSeconds(waitTime);
        if (moleStateAnimObject != null)
        {
            suddenCry = false;
            ChangeToCry();


        }
        
        

        //print("Coroutine ended: " + Time.time + " seconds");
    }

    private IEnumerator WaitAndChangeToTaunt(float waitTime)
    {

        //spawning = true;
        yield return new WaitForSeconds(waitTime);
        if (moleStateAnimObject != null)
        {
            
            moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 2);
            StopAllMoleAudio();
            aSArray[2].Play();
            


        }



        //print("Coroutine ended: " + Time.time + " seconds");
    }

    //Check if certain animation is playing in animator via name
    private bool IsPlaying(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private IEnumerator MoleIdleEnd(float waitTime)
    {

        //spawning = true;
        yield return new WaitForSeconds(waitTime);

        molePosAnimObject.GetComponent<Animator>().SetInteger("MolePositionAnimState", 1);

        /*
        if (IsPlaying(molePosAnimObject.GetComponent<Animator>(),"MolePositionIdle"))
        {
            molePosAnimObject.GetComponent<Animator>().SetBool("EndMolePosIdle", true);

        }
        */



        //print("Coroutine ended: " + Time.time + " seconds");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mole got hit!");
        //MoleState(4);//Doesn't work with HammerBehaviour OnTriggerEnter because this Trigger is invoked first before the Hammer trigger, see: (if other.GetComponent<MoleBehaviour>().moleState == 3)
        moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 4);
        StopAllMoleAudio();
        aSArray[4].Play();

        StopAllCoroutines();
        //molePosAnimObject.GetComponent<Animator>().SetInteger("MolePositionAnimState", 2);
        molePosAnimObject.GetComponent<Animator>().Play("MolePositionHit");
        this.GetComponent<Collider>().enabled = false;

    }

    private void StopAllMoleAudio()
    {
        for (int i=0; i<aSArray.Length; i++)
        {

            if (aSArray[i].isPlaying)
            {
                aSArray[i].Stop();

            }

        }


    }

    
    public void IncreaseDifficultyWithTime()
    {
        if (moleTimerReached60 == false)
        {
            if (moleTimer.seconds >= 60)
            {
                IncreaseDifficulty();
                moleTimerReached60 = true;
            }

            

        }
        
        if (moleTimerReached80 == false)
        {
            if (moleTimer.seconds >= 80)
            {
                IncreaseDifficulty();
                moleTimerReached80 = true;
            }

        }


    }
    

    public void IncreaseDifficulty()
    {
        

            cryProbabilityThreshold -= 0.25f;
            cryDelayLower -= 0.1f;
            cryDelayUpper -= 0.1f;
            endIdleDelayLower -= 0.1f;
            endIdleDelayUpper -= 0.1f;


        

    }



}
