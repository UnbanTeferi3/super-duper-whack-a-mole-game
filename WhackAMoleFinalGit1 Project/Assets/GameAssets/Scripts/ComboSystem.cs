using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class ComboSystem : MonoBehaviour
{

    [SerializeField] private int comboAmount;
    [SerializeField] private Text comboText;
    [SerializeField] private Text comboTextSec;
    [SerializeField] private StaminaBar staminaBar;

    [SerializeField] private float _comboStartTime;
    public float ComboStartTime { get => _comboStartTime; set => _comboStartTime = value; }
    
    [SerializeField] private float _comboTime = 0;
    public float ComboTime { get => _comboTime; set => _comboTime = value; }

    [SerializeField] private bool comboCanEnd = false;
    [SerializeField] private MoleTimer timer;

    //for audio
    [SerializeField] private float audioProb;
    [SerializeField] private AudioSource[] aSArray = new AudioSource[3];

    [SerializeField] private int comboMultiplier = 0;



    /*
    public int comboAmount;
    public Text comboText;
    public Text comboTextSec;
    public StaminaBar staminaBar;
    public float ComboStartTime = 3f;
    public float ComboTime = 0;
    public bool comboCanEnd = false;
    public MoleTimer timer;

    //for audio
    public float audioProb;
    public AudioSource[] aSArray = new AudioSource[3];

    public int comboMultiplier = 0;
    */

    private void Awake()
    {
        ComboStartTime = 3f;
        ComboTime = 0f;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ComboCountdown();

    }

    public void AddCombo()
    {

        comboAmount++;
        //comboAmount = 100;

        if (comboAmount > 1)
        {
            if (comboCanEnd == false)
            {

                comboCanEnd = true;

            }

            if ((comboAmount-1) % 5 == 0)//check if number is multiple of a number using modulus operation
            {
                Debug.Log("comboAmount reached 5!!!");
                comboMultiplier++;

                //playaudio
                aSArray[0].Play();
                
                timer.timerComboText.text = $"+{5*comboMultiplier}";
                timer.timerComboText.gameObject.GetComponent<Animator>().Play("ComboTextPop");
                timer.seconds += (5f * comboMultiplier)+1;

                comboText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
                comboText.color = Color.yellow;
                comboText.text = $"+{comboAmount - 1} COMBO!!";

                comboTextSec.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
                comboTextSec.color = Color.yellow;
                comboTextSec.text = $"+{(5f * comboMultiplier)} sec!!";

                Debug.Log("Playing cheer audio");

            }

            else if (((comboAmount - 1) % 5 != 0))
            {
                

                comboText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
                comboText.color = Color.yellow;
                comboText.text = $"+{comboAmount - 1} COMBO!!";
                ComboTime = ComboStartTime;

            }

            /*
            comboText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
            comboText.color = Color.yellow;
            comboText.text = $"+{comboAmount-1} COMBO!!";
            ComboTime = ComboStartTime;
            */
        }

    }

    public void ResetCombo()
    {

        comboAmount = 0;
        comboMultiplier = 0;

        if (comboCanEnd == true)
        {

            comboCanEnd = false;

        }
        //comboText.text = "";
        //comboText.text = "Combo Break";
    }

    public void ComboEnd()
    {
        comboAmount = 0;
        comboMultiplier = 0;
        ComboTime = 0;

        if (comboCanEnd == true)
        {

            
            StopAllComboAudio();
            aSArray[2].Play();
            //PlayComboEndAudio();

            comboText.color = new Color(1f, 0.65f, 0f, 1f);
            comboText.text = "Combo Break";
            comboText.gameObject.GetComponent<Animator>().Play("ComboTextShake", 0, 0);
            comboCanEnd = false;

        }
        
        
    }

    public void PlayComboEndAudio()
    {
        audioProb = Random.Range(0f, 1f);

        if (audioProb <= 0.3f)
        {
            aSArray[1].Play();
                
        }
        else
        {
            aSArray[2].Play();

        }
    }

    public void StopAllComboAudio()
    {
        foreach (AudioSource i in aSArray)
        {

            if (i.isPlaying)
            {
                i.Stop();
            }



        }
    }

    public void ComboCountdown()
    {
        if (ComboTime > 0)
        {

            ComboTime -= Time.deltaTime;
        }
        else if (ComboTime <= 0)
        {
            ResetCombo();

        }
        
        
        

    }

    
    /*
    public void ComboCalc(int state)
    {
        switch (state)
        {
            case 0:

                if (staminaBar.barSpeed != 0.4f)
                {

                    staminaBar.barSpeed = 0.4f;
                }

                break;

            case 3:

                if(staminaBar.barSpeed != 0.7f)
                {

                    staminaBar.barSpeed = 0.7f;
                }
                
                break;


            case 7:

                if (staminaBar.barSpeed != 5f)
                {

                    staminaBar.barSpeed = 5f;
                }
                break;

            default:
                
                break;
        }

    }
    */

    
}
