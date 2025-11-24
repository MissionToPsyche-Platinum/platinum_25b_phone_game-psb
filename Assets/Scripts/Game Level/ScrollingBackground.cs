using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;
// This script translates the 3D background for a scrolling effect


public class ScrollingBackground : MonoBehaviour
{
    public float speed;
    public Renderer quadRender;
    public string sortLayer = "Background";
    public int sortOrder = 0;
    private float legnth, startpos;
    public GameObject test;

    private void Start()
    {
        // old scrolling (does not work on Safari)
        // places the background at the very bottom of the order
        // quadRender.sortingLayerName = sortLayer;
        // quadRender.sortingOrder = sortOrder;

        // new scrolling
        startpos = transform.position.x;
    }
    void FixedUpdate()
    {
        // old scrolling (does not work on Safari)
        //the 3d texture continues to transform its position each update
        // quadRender.material.mainTextureOffset += new Vector2(0f, speed * Time.deltaTime);

        // new scrolling 
        if(Time.timeScale == 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);

            if(transform.position.y < -10.8)
                transform.position = new Vector3(transform.position.x, startpos, transform.position.z);
        }
        
    }
}
