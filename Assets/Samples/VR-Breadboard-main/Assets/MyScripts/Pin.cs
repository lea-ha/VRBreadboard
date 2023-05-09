using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public Boolean high = false;
    public Boolean isInputPin;
    void Start()
    {
        
    }

    public void onPointerEnter()
    {
        if(isInputPin)
        {
            if (high == false)
            {
                high = true;
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                high = false;
                gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (high)
        {
            GetComponent<Renderer>().material.color = Color.red;
        } else
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }
    }
}
