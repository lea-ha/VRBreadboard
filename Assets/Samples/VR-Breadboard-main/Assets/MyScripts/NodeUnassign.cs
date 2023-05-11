using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUnassign : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    private GameObject startCube;
    private GameObject endCube;
    private Pin startPin;
    private Pin endPin;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] pointer = GameObject.FindGameObjectsWithTag("Pointer");
        imgGaze = pointer[0].GetComponent<Image>();
        imgGaze.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgGaze.fillAmount = gvrTimer / totalTime;
        }

        if(gvrTimer > 2)
        {
            GameObject[] startNodes = GameObject.FindGameObjectsWithTag("StartNode");
            GameObject[] endNodes = GameObject.FindGameObjectsWithTag("EndNode");

            if (startNodes.Length == 0 && endNodes.Length == 0)
            {
                Transform parent = transform.parent;
                if (parent.tag == "SideNode")
                {
                    gameObject.tag = "StartNode";
                    startNodes = GameObject.FindGameObjectsWithTag("StartNode");
                }
            }

            if (startNodes.Length != 0 && endNodes.Length == 0)
            {
                Transform parent = gameObject.transform.parent;
                if (parent.tag == "Node")
                {
                    gameObject.tag = "EndNode";
                    endNodes = GameObject.FindGameObjectsWithTag("EndNode");

                    startCube = startNodes[0];
                    endCube = endNodes[0];
                    if (startCube.GetComponent<LineRenderer>() != null)
                    {
                        LineRenderer lineRenderer = startCube.GetComponent<LineRenderer>();
                        Destroy(lineRenderer);

                        if (parent.GetComponent<Node>() != null)
                        {
                            Debug.Log("parent has a node component!");
                            Node node = parent.GetComponent<Node>();
                            node.high = false;
                            Debug.Log(node.high);
                        }
                    }
                }
                startCube.tag = "Untagged";
                endCube.tag = "Untagged";



            }
        }
    }

    void OnPointerEnter()
    {
        gvrStatus = true;
    }

    void OnPointerExit()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }

}
