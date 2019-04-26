using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemImpl : MonoBehaviour, InventoryItem
{

    private ItemControl iControl;
    private ItemView iView;
    public string itemName;

    void Start()
    {
        iControl = GetComponentInChildren<ItemControl>();
        iView = GetComponentInChildren<ItemView>();
    }

    public string GetName()
    {
        return itemName;
    }

    public bool InInventory()
    {
        throw new System.NotImplementedException();
    }

    public void Enter()
    {
        if (iView != null && iControl != null)
        {
            iControl.ActivateControl();
            iView.Hide();
        }
        InventoryControl.control.Collect(this);
    }

    public void Remove(Vector3 position, Quaternion rotation)
    {
        if (iView != null && iControl != null)
        {
            iControl.DeactivateControl();
            iView.Remove(position, rotation);
        }
    }
}
