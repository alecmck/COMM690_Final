using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IButton : MonoBehaviour
{
    public Text t;
    private InventoryControl control;
    private string Name;
    private InventoryItem item;
    public void SetUp(InventoryItem i, InventoryControl c)
    {
        t.text = i.GetName();
        Name = i.GetName();
        control = c;
        item = i;
    }

    /*private void OnMouseDrag()
    {
        Debug.Log("MouseDrag");
        control.Use(item);
        this.gameObject.SetActive(false);
    }*/

    public void Use()
    {
        Debug.Log("Button clicked");
        control.Use(item);
        this.gameObject.SetActive(false);
    }
}
