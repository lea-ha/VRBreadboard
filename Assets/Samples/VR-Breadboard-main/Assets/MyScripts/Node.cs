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
        if(node1.high || node2.high || node3.high || node4.high || node5.high)
        {
            high = true;
            //this is working 
            foreach(Transform child in transform)
            {
                child.GetComponent<Pin>().high = true;
            } 
            
        } else
        {
            high = false;
            foreach (Transform child in transform)
            {
                Renderer renderer = child.GetComponent<Renderer>();
                renderer.material.color = Color.gray;
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
