using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using RTS;
using cakeslice;

public class UnitOutline : MonoBehaviour
{
    public GameObject unit;
    public Outline outline;

    private void LateUpdate()
    {
        if (Player.groups.Exists(unit))
        {
            if (!outline.outlined)
                outline.EnableOutline();
        }
        else
        {
            outline.DisableOutline();
        }
    }
}
