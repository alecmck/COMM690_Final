using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemSimple : MonoBehaviour, InventoryItem
{

    private bool inInventory;

    void Start()
    {
        inInventory = false;
    }


    public void Enter()
    {
        inInventory = true;
        InventoryControl.control.Collect(this);
        this.gameObject.SetActive(false);

    }   

    public string GetName()
    {
        return this.gameObject.name;
    }

    public bool InInventory()
    {
        return inInventory;
    }
    
    public void Remove(Vector3 position, Quaternion rotation)
    {
        inInventory = false;
        this.gameObject.SetActive(true);
        this.gameObject.transform.SetPositionAndRotation(position, rotation);
    }

    private void OnMouseDrag()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Enter();

        }
    }
}
