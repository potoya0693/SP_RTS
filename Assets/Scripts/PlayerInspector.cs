using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class PlayerInspector : MonoBehaviour
{
    public Faction faction;
    public List<GameObject> currentSelection;
    // Start is called before the first frame update
    void LateUpdate()
    {
        Player.faction = faction;
        currentSelection = Player.groups.GetGroup(0);
    }
}
