using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinNodeCollision : MonoBehaviour
{
    private outputAND pin;
    private Node myPin;
    // Start is called before the first frame update
    void Start()
    {
        Transform parent = transform.parent;

        myPin = parent.gameObject.GetComponent<Node>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pin")
        {
            if(other.GetComponent<outputAND>() != null)
            {
                pin = other.GetComponent<outputAND>();

                if (pin.high)
                {
                    myPin.high = true;
                }
                if (!pin.high)
                {
                    myPin.high = false;
                }
            }
            
        }
            
        
        
    }
}

