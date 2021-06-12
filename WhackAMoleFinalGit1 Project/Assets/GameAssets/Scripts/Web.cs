using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.UI;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class Web : MonoBehaviour
{
    public Action OnFinishGetWebRequestData; //create Action delegate for callback method
    public string jsonText;

    public GameObject errorWindow;
    public GameObject leaderBoardPanel;

    

    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("http://localhost/UnityPHPTutorial/GetDate.php"));
        //StartCoroutine(GetRequest("http://localhost/UnityPHPTutorial/GetUsers.php"));
        //StartCoroutine(Login("testuser3","123456"));
        //StartCoroutine(Register("testuser3", "123456"));

        //StartCoroutine(GetRequest("http://localhost/UnityPHPTutorial/GetScore.php"));


        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
    }

    public IEnumerator GetRequest(string uri)
    {
        

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;



            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);

            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                //Get and store the JSON result
                jsonText = webRequest.downloadHandler.text;
                OnFinishGetWebRequestData?.Invoke();

            }
        }
    }

    public IEnumerator GetLeaderboard(string uri)
    {
        ErrWindowPopUp();

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;



            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);

                ErrorWindowDisplayText("Couldn't connect to server.");

            }
            else
            {
                ErrWindowClose();
                LeaderBoardPopUp();

                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                //Get and store the JSON result
                jsonText = webRequest.downloadHandler.text;
                OnFinishGetWebRequestData?.Invoke();

            }
        }
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityPHPTutorial/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityPHPTutorial/Register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator SetScore(string username, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("userScore", score);
        

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityPHPTutorial/SetScore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator SubmitScore(string playerName, int playerScore)
    {
        ErrWindowPopUp();

        WWWForm form = new WWWForm();
        form.AddField("playerName", playerName);
        form.AddField("playerScore", playerScore);

        //Enable loading window here


        //using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityPHPTutorial/SubmitScoreLimited.php", form))
        using (UnityWebRequest www = UnityWebRequest.Post("https://duriangames.000webhostapp.com/WhackAMoleGame/MoleGameSubmitScoreLimited.php", form))
        {
            
            yield return www.SendWebRequest();

            

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

                ErrorWindowDisplayText("Couldn't connect to server.");


            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string[] results = www.downloadHandler.text.Split('/');
                int resultText = results.Length - 1;

                if (results[resultText] == "Score submitted successfully!")
                {
                    //Play success audio
                    Main.Instance.ScoreManager.scoreAS.Play();
                    Main.Instance.ScoreManager.scoreSubmitted = true;
                }

                ErrorWindowDisplayText(results[resultText]);
            }
        }
    }

    public void ErrWindowPopUp()
    {
        if (errorWindow.activeSelf == false)
        {
            errorWindow.SetActive(true);
            errorWindow.GetComponentInChildren<ErrorWindow>().errorWindowText.text = "Connecting to server...";
        }

    }

    public void ErrWindowClose()
    {

        if (errorWindow.activeSelf == true)
        {
            errorWindow.SetActive(false);
        }

    }

    public void ErrorWindowDisplayText(string displayText)
    {

        if (errorWindow.activeSelf == true)
        {
            errorWindow.GetComponent<ErrorWindow>().errorWindowText.text = displayText;
            if (errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.activeSelf == false)
            {
                errorWindow.GetComponent<ErrorWindow>().errorWindowCloseButton.SetActive(true);
            }

        }


    }

    public void LeaderBoardPopUp()
    {
        if (leaderBoardPanel.activeSelf == false)
        {
            leaderBoardPanel.SetActive(true);
            
        }

    }

}