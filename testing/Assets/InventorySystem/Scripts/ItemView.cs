using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemView
{

    void Remove(Vector3 position, Quaternion rotation);
    void Hide();
    bool visible();

}
