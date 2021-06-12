using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class HammerBehaviour : MonoBehaviour
{

    public Transform objectToMove;
    public Transform fXSpawner;
    public GameObject fXPrefab;
    public GameObject hitAudioPrefab1;
    public GameObject hitAudioPrefab2;

    //For stamina bar
    public StaminaBar staminaBar;
    public ComboSystem comboSystem;

    //Event/delegate to broadcast
    public delegate void OnMoleHitEventHandler();
    public static event OnMoleHitEventHandler OnMoleHit;

    public delegate void OnMoleCryHitEventHandler();
    public static event OnMoleCryHitEventHandler OnMoleCryHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        OnClickHammerMove();



    }


    public void PlayHammerAnim()
    {

        
        this.gameObject.GetComponentInChildren<Animator>().Play("Hammer1");
        //Debug.Log("HammerAnim is playing");

    }

    public void OnClickHammerMove()
    {
        
        //Keep note of this code, very useful
        if (Input.anyKeyDown)
        {

            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                //objectToMove.transform.position = hit.point;
                objectToMove.transform.position = new Vector3((hit.point.x), objectToMove.transform.position.y, hit.point.z);
            }
            PlayHammerAnim();
            PlayHammerSwingAudio();
            //staminaBar.barImage.fillAmount = 0;//reset stamina bar to 0


        }
        /*
        else if(Input.anyKeyDown && staminaBar.barPct != 1)
        {
            this.gameObject.GetComponentInChildren<Animator>().Play("HammerFail");
            staminaBar.barImage.fillAmount -= 0.4f;
            //code when hammer is swung but stamina isnt full
        }
        */
        


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hammer has hit mole");
        //fXObject.SetActive(true);
        GameObject fXInstance = Instantiate(fXPrefab, Vector3.zero, Quaternion.identity, fXSpawner);
        fXInstance.transform.localPosition = new Vector3(0, 0, 0);

        PlayHammerHitAudio();

        if (other.GetComponent<MoleBehaviour>().moleState == 3)
        {

            OnMoleCryHit?.Invoke();//Broadcast event/delegate
            comboSystem.ComboEnd();
            //comboSystem.ComboEnd();
            //other.GetComponent<MoleBehaviour>().hasBeenHit = true;
        }
        else 
        {

            OnMoleHit?.Invoke();//Broadcast event/delegate
            comboSystem.AddCombo();
            comboSystem.comboTime = comboSystem.comboStartTime;
            //other.GetComponent<MoleBehaviour>().hasBeenHit = true;

        }


        
        //other.GetComponent<MoleBehaviour>().MoleState(4);
        //other.GetComponent<MoleBehaviour>().moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 4);
        //other.GetComponent<Animator>().SetInteger("MolePositionAnimState", 2);
    }

    public void PlayHammerSwingAudio()
    {

        this.gameObject.GetComponent<AudioSource>().Play();

    }

    public void PlayHammerHitAudio()
    {
        Instantiate(hitAudioPrefab1);

        /*
        float hammerProb = Random.Range(0, 1f);
        if(hammerProb >= 0.5f)
        {
            Instantiate(hitAudioPrefab1);

        }
        else
        {
            Instantiate(hitAudioPrefab2);

        }
        */


    }

    /*
    public void EnableHammerCollider()
    {

        this.gameObject.GetComponent<Collider>().enabled = true;

    }

    public void DisableHammerCollider()
    {

        this.gameObject.GetComponent<Collider>().enabled = false;

    }
    */

    
}
