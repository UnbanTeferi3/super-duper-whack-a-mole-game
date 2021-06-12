using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class ComboSystem : MonoBehaviour
{
    public int comboAmount;
    public Text comboText;
    public Text comboTextSec;
    public StaminaBar staminaBar;
    public float comboStartTime = 3f;
    public float comboTime = 0;
    public bool comboCanEnd = false;
    public MoleTimer timer;

    //for audio
    public float audioProb;
    public AudioSource[] aSArray = new AudioSource[3];

    public int comboMultiplier = 0;

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
        if (comboAmount > 1)
        {
            if (comboCanEnd == false)
            {

                comboCanEnd = true;

            }

            if ((comboAmount-1) % 5 == 0)//check if number is multiple of a number using modulus operation
            {
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
                comboTime = comboStartTime;

            }

            /*
            comboText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
            comboText.color = Color.yellow;
            comboText.text = $"+{comboAmount-1} COMBO!!";
            comboTime = comboStartTime;
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
        comboTime = 0;

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
        if (comboTime > 0)
        {

            comboTime -= Time.deltaTime;
        }
        else if (comboTime <= 0)
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
