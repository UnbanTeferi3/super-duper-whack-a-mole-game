using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    [SerializeField] [Range(-1f, 1f)] private float _scrollSpeed;
    public float ScrollSpeed { get => _scrollSpeed; set => _scrollSpeed = value; }

    [SerializeField] private float offSet;
    [SerializeField] private Material mat;

    



    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
        offSet += (Time.deltaTime*ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offSet));


    }



}
