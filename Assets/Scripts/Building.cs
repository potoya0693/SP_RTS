using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class Building : MonoBehaviour
{
    [SerializeField]
    color m_color;
    [SerializeField]
    Unit m_Unit;

    private void OnMouseDown()
    {
        if (m_color == Player.faction.color)
        {
            Debug.Log("Select");
        }
    }
}
