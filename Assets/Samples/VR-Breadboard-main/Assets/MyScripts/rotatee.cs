using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatee : MonoBehaviour
{
    // Start is called before the first frame update

    public bool entered = false;

    public void pointerEnter()
    {
        entered = true;
        GetComponent<Renderer>().material.color = Color.green;

    }

    public void pointerExit()
    {
        entered = false;
        GetComponent<Renderer>().material.color = Color.white;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entered)
        {
            transform.Rotate(Vector3.up * 60 * Time.deltaTime);
        }
       
    }
}
