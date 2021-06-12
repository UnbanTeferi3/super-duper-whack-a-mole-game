using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;


public class Leaderboard : MonoBehaviour
{
    

    public string currentUsername;
    public int currentScore;
    //public Button SetScoreButton;
    //public Button GetScoreButton;
    public GameObject leaderBoardGO;
    public GameObject lBListingPrefab;
    public Transform lBListingParent;

    //JSONObject playerJson;
    

    public void OnEnable()
    {
        //Main.Instance.Web.OnFinishGetWebRequestData += SetJSONData;
    }

    public void OnDisable()
    {
        Main.Instance.Web.OnFinishGetWebRequestData -= SetJSONData;
    }

    // Start is called before the first frame update
    void Start()
    {
        Main.Instance.Web.OnFinishGetWebRequestData += SetJSONData;


        /*
        SetScoreButton.onClick.AddListener(() => {
            StartCoroutine(Main.Instance.Web.SetScore(currentUsername, currentScore));
        });

        GetScoreButton.onClick.AddListener(() => {
            StartCoroutine(Main.Instance.Web.GetRequest("http://localhost/UnityPHPTutorial/GetScore.php"));
        });
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetJSONData()
    {
        if (Main.Instance.Web.jsonText != null)
        {
            
            JSONArray playerJSONArray = (JSONArray)JSON.Parse(Main.Instance.Web.jsonText);
            JSONObject playerJson = new JSONObject();
            //playerJson.Add("Array",playerJSONArray);


            //playerJson = (JSONObject)playerJSONArray[2];

            string playerJsonText = playerJSONArray[2].AsObject["playername"]; //REMEMBER THIS SYNTAX TO EXTRACT JSON ARRAY DATA AS STRING!!!(SimpleJSON)

            //Or try seperating the string into array using split built in method





            Debug.Log(playerJsonText);
            //Debug.Log(playerJson["score"]);
            //currentScore = playerJson["score"];

            for (int i = 0; i < playerJSONArray.Count; i++)
            {
                GameObject lBListingInstance = Instantiate(lBListingPrefab, Vector3.zero, Quaternion.identity, lBListingParent) as GameObject;
                lBListingInstance.transform.localPosition = Vector3.zero;
                lBListingInstance.GetComponent<LeaderboardListing>().rankAndName.text = $"{i+1} " + playerJSONArray[i].AsObject["playername"];
                lBListingInstance.GetComponent<LeaderboardListing>().score.text = playerJSONArray[i].AsObject["score"];
            }


            

        }
        

    }

    public void GetScore()
    {       
        StartCoroutine(Main.Instance.Web.GetLeaderboard("https://duriangames.000webhostapp.com/WhackAMoleGame/MoleGameGetScoreFinal.php"));
    }

    public void EnableLeaderboard()
    {
        if(leaderBoardGO.activeSelf == false)
        {
            leaderBoardGO.SetActive(true);
        }
        

    }

    public void DisableLeaderboard()
    {
        foreach (Transform child in lBListingParent)
        {
            Destroy(child.gameObject);
        }

        if (leaderBoardGO.activeSelf == true)
        {
            leaderBoardGO.SetActive(false);
        }




    }


}
