using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerColliderManager : MonoBehaviour
{
    public GameObject hammerColliderObject;
    public bool colliderAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHammerCollider()
    {
        if (colliderAllowed == true)
        {
            hammerColliderObject.GetComponent<Collider>().enabled = true;
        }
        

    }

    public void DisableHammerCollider()
    {
        if (hammerColliderObject.GetComponent<Collider>().enabled == true)
        {
            hammerColliderObject.GetComponent<Collider>().enabled = false;
        }
        

    }
}
