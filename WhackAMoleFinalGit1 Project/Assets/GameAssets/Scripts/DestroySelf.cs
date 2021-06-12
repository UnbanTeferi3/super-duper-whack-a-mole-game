using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public float delay;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(DelaySelfDestroy(delay));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelaySelfDestroy(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);

    }
}
