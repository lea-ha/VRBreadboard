using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Boolean high = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onPointerEnter()
    {
        
            if (high == false)
            {
                high = true;
            }
            else
            {
                high = false;
            }
        

    }
    // Update is called once per frame
    void Update()
    {
        if (high)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }

    }
}
