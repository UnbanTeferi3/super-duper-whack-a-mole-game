using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollHandleBarFixedSize : MonoBehaviour
{
    /*
    This is a hack to fix the size of the scrollbar's handlebar. For this to work make sure that the ScrollBar
    game object is dragged into the OnValueChanged(Vector2) field in the ScrollView game object's component inspector
    (which is usally the parent of the ScrollBar game object) and set the ScrollBar size to the desired value.
    */

    [Range(0f, 1f)] public float handleBarSize;

    

    // Start is called before the first frame update
    void Start()
    {
        //transform.GetComponent<Scrollbar>().size = 0;
        //Debug.Log(transform.GetComponent<Scrollbar>().size);
        StartCoroutine(SetHandleBarSize(Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.GetComponent<Scrollbar>().size = 0;
    }

    IEnumerator SetHandleBarSize(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        if (transform.GetComponent<Scrollbar>().size != handleBarSize){
            transform.GetComponent<Scrollbar>().size = handleBarSize;
        }
        

    }
}
