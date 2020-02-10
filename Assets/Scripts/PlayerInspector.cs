using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class PlayerInspector : MonoBehaviour
{
    public Faction faction;
    // Start is called before the first frame update
    void Start()
    {
        Player.faction = faction;
    }
}
