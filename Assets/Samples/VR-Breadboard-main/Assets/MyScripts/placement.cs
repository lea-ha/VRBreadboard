using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class placement : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    public GameObject reticle;
    private Rigidbody IC;

    private GameObject chip;
    private GameObject node;
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

        if (gvrTimer > 2)
        {
            GameObject[] chips = GameObject.FindGameObjectsWithTag("Chip");
            if (chips.Length == 0 && gameObject.GetComponent<Pin>() == null)
            {
                gameObject.tag = "Chip";
                IC = gameObject.GetComponent<Rigidbody>();

                IC.transform.parent = reticle.transform;
                IC.transform.localPosition = reticle.transform.localPosition;
            }

            if (chips.Length != 0 && gameObject.GetComponent<Pin>() != null)
            {
                GameObject[] ICs = GameObject.FindGameObjectsWithTag("Chip");
                IC = ICs[0].GetComponent<Rigidbody>();
                IC.transform.parent = null;
                IC.transform.position = new Vector3(gameObject.transform.position.x + -1f, gameObject.transform.position.y + 0.2f, gameObject.transform.position.z + -0.4f);
                IC.transform.rotation = Quaternion.Euler(-90, 0, 0);
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