using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CountdownBehaviour : MonoBehaviour
{
    public Text countdownText;
    public float countdownDelay;
    //public int countDownNumber;
    public int countDownStart;

    //for audio
    public AudioSource[] aSCountdown = new AudioSource[2];

    //event/delegates
    public delegate void OnFinishCountDownEventHandler();
    public static event OnFinishCountDownEventHandler OnFinishCountDown;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndCountDown(countdownDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator WaitAndCountDown(float waitTime)
    {
        for (int i = countDownStart; i >= 0; i--)
        {

            yield return new WaitForSeconds(waitTime);
            //countDownNumber++;
            if (i == 0)
            {
                
                countdownText.text = "";
                OnFinishCountDown?.Invoke();

            }
            else if (i == 1)
            {
                countdownText.text = "GO!";
                aSCountdown[1].Play();

            }
            else
            {
                countdownText.text = $"{i-1}";
                aSCountdown[0].Play();

            }
            

        }
        
        



        
    }
}
