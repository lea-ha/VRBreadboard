using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputNOT : MonoBehaviour
{
    public Pin pin1, pinVcc;

    public Boolean high = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pin1.high && pinVcc.high)
        {
            high = false;
        }
        else if(!pin1.high && pinVcc.high)
        {
            high = true;
        }
        else
        {
            high = false;
        }

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
