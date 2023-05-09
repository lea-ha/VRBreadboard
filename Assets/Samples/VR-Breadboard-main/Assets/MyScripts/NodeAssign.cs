using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NodeAssign : MonoBehaviour
{
    private GameObject startCube;
    private GameObject endCube;
    private Renderer startRender;
    private Renderer endRender;
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

    public void OnPointerEnter()
    {
        GameObject[] startNodes = GameObject.FindGameObjectsWithTag("StartNode");
        GameObject[] endNodes = GameObject.FindGameObjectsWithTag("EndNode");

        if (startNodes.Length != 0 && endNodes.Length == 0)
        {
            gameObject.tag = "EndNode";
            endNodes = GameObject.FindGameObjectsWithTag("EndNode");

            startCube = startNodes[0];
            endCube = endNodes[0];
            CreateWire();
            startPin = startCube.GetComponent<Pin>();
            endPin = endCube.GetComponent<Pin>();
            if (startPin.high)
            {
                endPin.high = true;
            }
            else
            {
                endPin.high = false;
            }
            startCube.tag = "Node";
            endCube.tag = "Node";
        }

        if (startNodes.Length == 0 && endNodes.Length == 0)
        {
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                // The object has a Line Renderer component
                Debug.Log("Invalid Node");
                Destroy(lineRenderer);
            }
            else
            {
                gameObject.tag = "StartNode";
            }

        }

    }

    public void CreateWire()
    {

        LineRenderer lineRenderer = startCube.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;

        Vector3[] positions = new Vector3[2];
        positions[0] = startCube.transform.position + Vector3.up * (startCube.transform.localScale.y / 2 + 0.1f);
        positions[1] = endCube.transform.position + Vector3.up * (endCube.transform.localScale.y / 2 + 0.1f);
        lineRenderer.SetPositions(positions);

        

    }
}