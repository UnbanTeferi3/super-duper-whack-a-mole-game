using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance; //For making this a singleton script

    public Web Web;
    public Leaderboard Leaderboard;
    public ScoreManager ScoreManager;

    private void OnEnable()
    {
        //DontDestroyOnLoad(this.gameObject);
        Instance = this; //For making this a singleton script

        Web = GetComponent<Web>();
        Leaderboard = GetComponent<Leaderboard>();
        ScoreManager = GetComponentInChildren<ScoreManager>();

    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
