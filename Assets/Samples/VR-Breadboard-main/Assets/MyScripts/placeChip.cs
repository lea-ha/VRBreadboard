using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class placeChip : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    private GameObject chip;
    public GameObject RemoverImage;
    public GameObject AdderImage;
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
