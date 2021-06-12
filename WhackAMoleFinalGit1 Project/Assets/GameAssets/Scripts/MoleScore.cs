using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleScore : MonoBehaviour
{
    public int points;
    public Text pointsText;
    public Text pointsAddedText;

    private void OnEnable()
    {
        //MoleBehaviour.OnMoleDestroyed += spawningToFalse;
        HammerBehaviour.OnMoleHit += AddPoints; //listen to event broadcast
        HammerBehaviour.OnMoleCryHit += DeductPoints;
    }

    private void OnDisable()
    {
        HammerBehaviour.OnMoleHit -= AddPoints;//unlisten
        HammerBehaviour.OnMoleCryHit -= DeductPoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (points <= 0)
        {

            points = 0;
            pointsText.text = "0";

        }
    }

    public void AddPoints()
    {
        points++;
        pointsText.text = $"{points}";
        pointsAddedText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
        pointsAddedText.color = Color.yellow;
        pointsAddedText.text = "+1";

    }

    public void DeductPoints()
    {
        points -= 5;
        pointsText.text = $"{points}";
        pointsAddedText.gameObject.GetComponent<Animator>().Play("ComboTextPop", 0, 0);
        pointsAddedText.color = new Color(1f, 0.65f, 0f, 1f);
        pointsAddedText.text = "-5";
    }
}
