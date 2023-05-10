using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Pin node1, node2, node3, node4, node5;
    public Boolean high = false;

    void setHigh()
    {
        

        if (high)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Pin>().high = true;
            }
        }

        if (!high)
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Pin>().high = false;
            }
        }
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setHigh();
    }
}
