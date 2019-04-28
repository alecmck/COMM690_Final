using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPhoneCable : MonoBehaviour, InventoryItem
{
    public PartOne mySegment;
    public GameObject wireEnd;
    public GameObject wireStart;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseDrag()
    {
        Debug.Log("Click red wire");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("setdeactive");
            Enter();
            wireEnd.SetActive(false);
            wireStart.SetActive(false);
        }        
    }

    public string GetName()
    {
        return "Red Cable";
    }

    public bool InInventory()
    {
        return false;
    }

    public void Enter()
    {
        InventoryControl.control.Collect(this);
    }

    public void Remove(Vector3 position, Quaternion rotation)
    {
        wireEnd.SetActive(true);
        wireStart.SetActive(true);
    }
}
