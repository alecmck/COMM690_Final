using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crosshairLogic : MonoBehaviour
{
    public Image crosshair;
    public Sprite newSprite;
    public Sprite storedCrosshair;

    //move this intro dragrigidbody script???
    void Start()
    {
        storedCrosshair = crosshair.sprite;
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            crosshair.enabled = false;
        }
        else
        {
            crosshair.enabled = true;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if (hit.transform.tag == "DynamicObject")
            {
                //Debug.Log(hit.transform.name);
                crosshair.sprite = newSprite;

            }
            else
            {
                crosshair.sprite = storedCrosshair;
            }
        }
        else
        {
            crosshair.sprite = storedCrosshair;
        }
    }
}
