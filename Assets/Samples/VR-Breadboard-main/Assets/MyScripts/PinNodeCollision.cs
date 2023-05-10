using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinNodeCollision : MonoBehaviour
{
    
    private Node myPin;
    private outputAND andpin;
    private outputNAND nandpin;
    private outputOR orpin;
    private outputNOR norpin;
    private outputNOT notpin;
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
                andpin = other.GetComponent<outputAND>();

                if (andpin.high)
                {
                    myPin.high = true;
                }
                if (!andpin.high)
                {
                    myPin.high = false;
                }
            }
            if (other.GetComponent<outputNAND>() != null)
            {
                nandpin = other.GetComponent<outputNAND>();

                if (nandpin.high)
                {
                    myPin.high = true;
                }
                if (!nandpin.high)
                {
                    myPin.high = false;
                }
            }
            if (other.GetComponent<outputOR>() != null)
            {
                orpin = other.GetComponent<outputOR>();

                if (orpin.high)
                {
                    myPin.high = true;
                }
                if (!orpin.high)
                {
                    myPin.high = false;
                }
            }

            if (other.GetComponent<outputNOR>() != null)
            {
                norpin = other.GetComponent<outputNOR>();

                if (norpin.high)
                {
                    myPin.high = true;
                }
                if (!norpin.high)
                {
                    myPin.high = false;
                }
            }
            if (other.GetComponent<outputNOT>() != null)
            {
                Debug.Log("Itsa NOT!");
                notpin = other.GetComponent<outputNOT>();

                if (notpin.high)
                {
                    myPin.high = true;
                }
                if (!notpin.high)
                {
                    myPin.high = false;
                }
            }

        }
            
        
        
    }
}

