using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

[CreateAssetMenu(menuName = "UnitOptions")]
public class UnitOptions : ScriptableObject
{
    public Unit targetUnit;
    public GameObject[] options;
}
