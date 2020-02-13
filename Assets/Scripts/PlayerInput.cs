using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    public Action OnRightClick;
    public Action OnLeftClick;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
            OnLeftClick?.Invoke();

        if (Input.GetMouseButtonUp(1))
            OnRightClick?.Invoke();

    }
}
