using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ScoreManager : MonoBehaviour
{
    public int totalScore;
    public MoleScore moleScore;
    public Text totalScoreText;
    public GameObject[] textImageArray;
    public InputField inputField;
    public GameObject errorWindow;
    public AudioSource scoreAS;
    public bool scoreSubmitted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalScore = moleScore.points;
    }

    private void EnableTextImage(int index)
    {
        if (textImageArray[index].activeSelf == false)
        {
            textImageArray[index].SetActive(true);

        }
        


    }

    public void UpdateTotalScoreText()
    {
        if (totalScore < 20)
        {

            EnableTextImage(0);
            totalScoreText.text = $"Your total score is <color=yellow>{totalScore}</color> points. I'm sure you can do better. Try again?";

        }
        else if(totalScore >= 20 && totalScore < 60)
        {
            EnableTextImage(1);
            totalScoreText.text = $"Your total score is <color=yellow>{totalScore}</color> points! Not bad at all! Try again?";

        }
        else if (totalScore >= 60)
        {
            EnableTextImage(2);
            totalScoreText.text = $"Your total score is <color=yellow>{totalScore}</color> points! You did extremely well! Good job!";

        }
       

    }

    public void SubmitFieldAllCaps()
    {
        string text = inputField.text;
        if (text != inputField.text.ToUpper())
        {
            inputField.text = inputField.text.ToUpper();
        }

        //inputField.text.ToUpper();
        //Debug.Log(inputField.text);
    }

    public void SubmitScore()
    {
        
        //guard clause 1
        if(inputField.text == "")
        {
            Debug.Log("Please enter a name");
            if(errorWindow.activeSelf == false)
            {
                errorWindow.SetActive(true);

                errorWindow.GetComponent<ErrorWindow>().errorWindowText.text = "Please enter a name.";

                if (errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.activeSelf == false)
                {
                    errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.SetActive(true);
                }
                   
            }
            return;
        }

        //guard clause 2
        if(scoreSubmitted == true)
        {
            if(errorWindow.activeSelf == false)
            {
                errorWindow.SetActive(true);

                errorWindow.GetComponent<ErrorWindow>().errorWindowText.text = "Score already submitted.";

                if (errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.activeSelf == false)
                {
                    errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.SetActive(true);
                }

            }
            return;
        }

        StartCoroutine(Main.Instance.Web.SubmitScore(inputField.text, moleScore.points));
        
    }

    public void ResetScoreSubmitted()
    {

        if (scoreSubmitted == true)
        {
            scoreSubmitted = false;
        }
    }

    
}
