using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBehavior : MonoBehaviour
{
    public GameObject RemoverImage;
    public GameObject AdderImage;
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
        AdderImage.SetActive(true);
        RemoverImage.SetActive(false);
        
        GameObject[] Nodes = GameObject.FindGameObjectsWithTag("Node");
        GameObject[] SideNodes = GameObject.FindGameObjectsWithTag("SideNode");

        foreach (GameObject Node in Nodes)
        {
            foreach (Transform child in Node.transform)
            {

                if (child.GetComponent<NodeUnassign>() != null)
                {

                    NodeUnassign unassign = child.GetComponent<NodeUnassign>();
                    Destroy(unassign);

                }
                if (child.GetComponent<NodeAssign>() == null)
                {
                    NodeAssign assign = child.gameObject.AddComponent<NodeAssign>();
                    assign.enabled = true;
                }
            }

        }
        foreach (GameObject SideNode in SideNodes)
        {
            foreach (Transform child in SideNode.transform)
            {

                if (child.GetComponent<NodeUnassign>() != null)
                {

                    NodeUnassign unassign = child.GetComponent<NodeUnassign>();
                    Destroy(unassign);
                    Debug.Log("Destroyed unassign");
                }
                if (child.GetComponent<NodeAssign>() == null)
                {
                    NodeAssign assign = child.gameObject.AddComponent<NodeAssign>();
                    assign.enabled = true;
                }
            }

        }
    }
}
