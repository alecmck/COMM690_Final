using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public GameObject light;
    public GameObject objectA;
    private bool collected;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectA.SetActive(false);
            collected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                light.SetActive(on);
                on = !on;
            }
        }
    }
}
