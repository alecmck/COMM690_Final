using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemControl
{
    void ActivateControl();
    void DeactivateControl();
    bool IsControlActive();
}