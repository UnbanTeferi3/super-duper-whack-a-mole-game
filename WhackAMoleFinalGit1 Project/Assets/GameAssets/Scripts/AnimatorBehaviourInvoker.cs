using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehaviourInvoker : MonoBehaviour
{
    [SerializeField] private GameObject scriptGameObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallScriptGOMethod()
    {
        //moleStateAnimObject.GetComponent<Animator>().SetInteger("AnimState", 2);
        scriptGameObject.GetComponent<Animator>().SetInteger("AnimState", 2); ;

    }
}
