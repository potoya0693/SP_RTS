using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS;

public class PlayerController : MonoBehaviour
{
    public GameObject moveFlag;

    private void Start()
    {
        FindObjectOfType<PlayerInput>().OnRightClick = TryCommandUnits;
    }

    private void TryCommandUnits()
    {
        RaycastHit hit = CastMouseRay();

        //If we hit a Unit, issue an target command.
        if (hit.collider.GetComponent<Unit>())
        {

        }
        else
        {
            //If nothing else, issue a move.
            SendGroupMessage("SetMoveCoordinates", hit.point);
        }

    }

    private void SendGroupMessage(string message, object value)
    {
        if (value != null)
            RTS.Player.groups.SendMessages(message, value);
        else
            RTS.Player.groups.SendMessages(message);
    }



    private RaycastHit CastMouseRay()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(mouseRay, out hit);
        return hit;
    }
}
