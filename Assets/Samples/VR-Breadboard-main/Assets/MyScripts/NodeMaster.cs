using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMaster : MonoBehaviour
{
    public Rigidbody IC;
    public Transform TheHolder;
    public GameObject AllTheNodes;

    public void inMyHands()
    {
        IC.transform.parent = TheHolder.transform; 
        IC.transform.localPosition= TheHolder.transform.localPosition;

        AllTheNodes.SetActive(true);    

    }

    public void onTheNodes()
    {
        IC.transform.parent = null;
        IC.transform.localPosition = TheHolder.transform.localPosition;

        AllTheNodes.SetActive(false);
    }
   
}
