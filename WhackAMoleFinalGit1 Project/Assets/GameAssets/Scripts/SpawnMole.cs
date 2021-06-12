using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SpawnMole : MonoBehaviour
{
    
    public GameObject molePrefab;
    //public GameObject moleInstance;
    public Transform moleSpawnPoint;
    //public GameObject[] moleSpawnPoints = new GameObject[6];
    public bool spawning = false;
    public GameObject moleInstance;
    public float delayUpper;
    public float delayLower;
    public bool allowedToStart = false;
    

    void OnEnable()
    {

        CountdownBehaviour.OnFinishCountDown += AllowMoleStart;

    }

    void OnDisable()
    {

        CountdownBehaviour.OnFinishCountDown -= AllowMoleStart;

    }


    // Start is called before the first frame update
    void Start()
    {
        //MoleBehaviour.
    }

    // Update is called once per frame
    void Update()
    {
        if (allowedToStart)
        {

            if (spawning == false)
            {

                StartCoroutine(WaitAndSpawn(UnityEngine.Random.Range(delayLower, delayUpper)));

            }



        }


    }

    public void AllowMoleStart()
    {
        if (allowedToStart != true)
        {
            allowedToStart = true;

        }

        



    }

    public void SpawnMolePrefab()
    {
        
        
        moleInstance = Instantiate(molePrefab, Vector3.zero, Quaternion.identity, moleSpawnPoint);
        moleInstance.transform.localPosition = new Vector3(0, -11f, 0);
        

        
        
        //spawning = true;
        

    }

    public void DestroyMolePrefab()
    {
        if (moleInstance != null)
        {

            Destroy(moleInstance);
            spawning = false;

        }
        
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {
        spawning = true;
        yield return new WaitForSeconds(waitTime);
        SpawnMolePrefab();

        //print("Coroutine ended: " + Time.time + " seconds");
    }

    public void SpawningToFalse()//Might not be in use, check again later
    {
        spawning = false;
        Debug.Log("Hole is free");

    }
}
