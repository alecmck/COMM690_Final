using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    // Start is called before the first frame update
    public string color;

    public void OnMouseDown()
    {
        Debug.Log("Clicked Phone " + color);
        if (color.Equals("Red"))
        {
            Debug.Log("sending red to controller");
            GameController.control.DarkPhoneClicked();
        }
        else
        {
            Debug.Log("sending blue to controller");
            GameController.control.LightPhoneClicked();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
