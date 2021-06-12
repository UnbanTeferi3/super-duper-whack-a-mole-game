using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image barImage;


    public float barSpeed = 0.4f;


    public float barPct;


    //[SerializeField] private float barPct;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FillBar(barSpeed);
    }

    private void FillBar(float speed)
    {

        if (barImage.fillAmount != 1)
        {
            if(barImage.color != Color.white)
            {
                barImage.color = Color.white;

            }
            
            barImage.fillAmount += Time.deltaTime*speed;
            barPct = barImage.fillAmount;
            

        }
        else if (barImage.fillAmount == 1)
        {
            barImage.color = Color.yellow;
        }


    }
}
