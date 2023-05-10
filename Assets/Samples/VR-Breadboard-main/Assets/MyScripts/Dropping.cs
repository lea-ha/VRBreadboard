using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropping : MonoBehaviour
{

    public Rigidbody IC;
    public Transform newPosition;

    // Start is called before the first frame update
    void Start()
    {
        IC.transform.parent= null;
        IC.transform.localPosition = newPosition.transform.localPosition;
    }
}
