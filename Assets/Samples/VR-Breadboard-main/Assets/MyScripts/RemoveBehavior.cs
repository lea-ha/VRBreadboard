using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBehavior : MonoBehaviour
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

        RemoverImage.SetActive(true);
        AdderImage.SetActive(false); ;
        GameObject[] Nodes = GameObject.FindGameObjectsWithTag("Node");
        GameObject[] SideNodes = GameObject.FindGameObjectsWithTag("SideNode");

        foreach(GameObject Node in Nodes)
        {
            foreach(Transform child in Node.transform)
            {
                
                if (child.GetComponent<NodeAssign>() != null)
                {
                    
                    NodeAssign assign = child.GetComponent<NodeAssign>();
                    assign.enabled = false;
                    Destroy(assign);
                   
                }
                if (child.GetComponent<NodeUnassign>() == null)
                {
                    NodeUnassign unassign = child.gameObject.AddComponent<NodeUnassign>();
                    unassign.enabled = true;
                }
            }
            
        }
        foreach (GameObject SideNode in SideNodes)
        {
            foreach(Transform child in SideNode.transform)
            {
                if (child.GetComponent<NodeAssign>() != null)
                {
                    
                    NodeAssign assign = child.GetComponent<NodeAssign>();
                    assign.enabled = false;
                    Destroy(assign);
                    
                }
                if (child.GetComponent<NodeUnassign>() == null)
                {
                    NodeUnassign unassign = child.gameObject.AddComponent<NodeUnassign>();
                    unassign.enabled = true;
                }
            }
            
        }
    }
}
