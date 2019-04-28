using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePhoneCable : MonoBehaviour, InventoryItem
{
    public PartOne mySegment;

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
        Debug.Log("Click blue wire");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("setdeactive");
            Enter();
            this.gameObject.SetActive(false);
        }
    }

    public string GetName()
    {
        return "Blue Cable";
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
        this.gameObject.SetActive(true);
        this.gameObject.transform.SetPositionAndRotation(position, rotation);

    }
}
