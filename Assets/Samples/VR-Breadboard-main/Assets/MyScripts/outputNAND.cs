using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outputNAND : MonoBehaviour
{
    public Pin pin1, pin2;
    public Pin Vcc;

    public Boolean high = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!(pin1.high && pin2.high) && Vcc.high)
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
