using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinNodeCollision : MonoBehaviour
{
    private outputNAND pin;
    private Pin myPin;
    // Start is called before the first frame update
    void Start()
    {
        myPin = GetComponent<Pin>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.name == "pin3")
        {
            pin = other.GetComponent<outputNAND>();

            if (pin.high == true)
            {
                myPin.high = true;
            }
        }
        
    }
}

