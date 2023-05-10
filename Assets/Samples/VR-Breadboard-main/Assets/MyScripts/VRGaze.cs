using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{
    public Image imgGaze;
    public float totalTime = 2;
    bool gvrStatus;
    float gvrTimer;

    static public GameObject hand;
    public Transform handtrans = hand.transform;

    public int distance = 10;
    private RaycastHit _hit;

    void Start()
    {
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

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        if (Physics.Raycast(ray, out _hit, distance))
        {
            if (imgGaze.fillAmount == 1 && _hit.transform.CompareTag("IC") && gvrStatus)
            {
                _hit.transform.SetParent(handtrans);

                gvrStatus = false;
            }
        }
    }

    public void GVROn()
    {
        gvrStatus = true;
    }
    public void GVROff()
    {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }

    public void OnPointerEnter()
    {
        GVROn();
        Debug.Log("Entered IC");
    }

    public void OnPointerExit()
    {
        GVROff();
        Debug.Log("Exited IC");
    }
}
