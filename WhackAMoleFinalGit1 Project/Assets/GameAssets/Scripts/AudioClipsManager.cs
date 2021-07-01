using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioClipsManager : MonoBehaviour
{
    [SerializeField] private GameObject[] audioSourceGOArray;
    [SerializeField] private AudioSource[] audioSourceArray;
    [SerializeField] private bool subscribeToOnFinishCountDown = false;


    void OnEnable()
    {
        if(subscribeToOnFinishCountDown == true)
        {
            CountdownBehaviour.OnFinishCountDown += PlaySecondAudioSourceClip;
        }
        

    }

    void OnDisable()
    {
        if (subscribeToOnFinishCountDown == true)
        {
            CountdownBehaviour.OnFinishCountDown -= PlaySecondAudioSourceClip;
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudioRandomly()
    {

        int i = Random.Range(0, audioSourceArray.Length);

        audioSourceArray[i].Play();




    }

    public void InstantiateAllASGO()
    {
        if(audioSourceGOArray.Length == 0)
        {
            return;

        }

        for(int i = 0; i<audioSourceGOArray.Length; i++)
        {

            Instantiate(audioSourceGOArray[i], new Vector3(0, 0, 0), Quaternion.identity);

        }

    }

    public void PlayAudioSourceClip(int i)
    {
        if (audioSourceArray[i].isPlaying == false)
        {
            audioSourceArray[i].Play();
        }
        

    }

    public void StopAudioSourceClip(int i)
    {

        if (audioSourceArray[i].isPlaying == true)
        {
            audioSourceArray[i].Stop();
        }

    }

    public void PlaySecondAudioSourceClip()
    {
        PlayAudioSourceClip(1);
    }

}
