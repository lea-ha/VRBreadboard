using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePinCollision : MonoBehaviour
{
    private Pin pin;
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
        pin = other.GetComponent<Pin>();
        if (pin.high)
        {
            myPin.high = true;
        }
        else
        {
            myPin.high = false;
        }
    }
}

