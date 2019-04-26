using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryItem
{
    string GetName();
    bool InInventory();
    void Enter();
    void Remove(Vector3 position, Quaternion rotation);

}
