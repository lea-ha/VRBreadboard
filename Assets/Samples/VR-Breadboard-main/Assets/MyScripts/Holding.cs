using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holding : MonoBehaviour
{
    public Transform MyHand;
    public Rigidbody IC;
    // Start is called before the first frame update
    void Start()
    {
        IC.transform.parent = MyHand.transform;
        IC.transform.localPosition= MyHand.transform.localPosition;
        //IC.transform.position = new Vector3(MyHand.transform.position.x, MyHand.transform.position.y, MyHand.transform.position.z);
    }

    
}
