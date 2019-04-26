using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHide : MonoBehaviour, ItemView
{

    private bool isVisible = true;



    public void Hide()
    {
        this.gameObject.SetActive(false);
        isVisible = false;
    }

    public void Remove(Vector3 position, Quaternion rotation)
    {
        Debug.Log("Calling Remove in ShowHide");
        this.gameObject.SetActive(true);
        this.gameObject.transform.SetPositionAndRotation(position, rotation);
        isVisible = true;
    }

    public bool visible()
    {
        return isVisible;
    }


    private void OnMouseDrag()
    {
        Debug.Log("Dragging Flashlight");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Notifying");
            this.GetComponentInParent<InventoryItem>().Enter();
        }
    }
}
