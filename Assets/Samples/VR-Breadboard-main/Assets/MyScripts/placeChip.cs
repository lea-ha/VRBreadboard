using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class placeChip : MonoBehaviour
{
    private GameObject chip;
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
        AdderImage.SetActive(false);
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
                    NodeAssign assign = child.GetComponent<NodeAssign>();
                    Destroy(assign);

                }
                if (child.GetComponent<placement>() == null)
                {
                    placement place = child.gameObject.AddComponent<placement>();
                    place.enabled = true;
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
                    NodeAssign assign = child.GetComponent<NodeAssign>();
                    Destroy(assign);

                }
                if (child.GetComponent<placement>() == null)
                {
                    placement place = child.gameObject.AddComponent<placement>();
                    place.enabled = true;
                }
            }
        }
     }
}
