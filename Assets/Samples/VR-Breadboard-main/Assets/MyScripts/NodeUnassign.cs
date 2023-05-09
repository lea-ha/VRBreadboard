using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUnassign : MonoBehaviour
{

    private GameObject startCube;
    private GameObject endCube;
    private Pin startPin;
    private Pin endPin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPointerEnter()
    {
        GameObject[] startNodes = GameObject.FindGameObjectsWithTag("StartNode");
        GameObject[] endNodes = GameObject.FindGameObjectsWithTag("EndNode");

        if (startNodes.Length != 0 && endNodes.Length == 0)
        {
            gameObject.tag = "EndNode";
            endNodes = GameObject.FindGameObjectsWithTag("EndNode");
            startCube = startNodes[0];
            endCube = endNodes[0];
            startPin = startCube.GetComponent<Pin>();
            endPin = endCube.GetComponent<Pin>();
            LineRenderer wire = startCube.GetComponent<LineRenderer>();
            if (wire != null && startPin.high)
            {
                Destroy(wire);
                endPin.high = false;
            }
        }

        if (startNodes.Length == 0 && endNodes.Length == 0)
        {

            gameObject.tag = "StartNode";

        }
    }

}
