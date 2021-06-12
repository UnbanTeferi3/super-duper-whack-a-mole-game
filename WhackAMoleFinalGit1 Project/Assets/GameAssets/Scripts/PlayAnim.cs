using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayAnim : MonoBehaviour
{
    public string animName;
   
    public Animator anim;

    /*
    private void Awake()
    {
        if (this.gameObject.GetComponent<Animator>() != null)
        {

            anim = this.gameObject.GetComponent<Animator>();

        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnimMethod()
    {
        

        
        anim.Play(animName);

    }
}
