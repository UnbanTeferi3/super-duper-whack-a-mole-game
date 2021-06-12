using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMoleList : MonoBehaviour
{

    public List<SpawnMole> spawnMoleList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void DisableAllSpawnMole()
    {
        //guard clause
        if (spawnMoleList.Count == 0)
        {

            return;
        }

        

        foreach (SpawnMole i in spawnMoleList)
        {
            if (i.enabled == true)
            {

                i.enabled = false;
                i.GetComponent<SpawnMole>().StopAllCoroutines();
            }
            

        }

    }
}
