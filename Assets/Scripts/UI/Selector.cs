using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using RTS;

public class Selector : MonoBehaviour
{
    bool m_selecting;
    Vector3 m_startPointer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_selecting = true;
            m_startPointer = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0))
        {
            m_selecting = false;
            List<GameObject> gObjList = new List<GameObject>();
            //Iterate through possible options, and add those under rect bounds.
            foreach (Unit i in SelectableUnits)
            {
                if (IsWithinSelectionBounds(i.gameObject))
                {
                    gObjList.Add(i.gameObject);
                }
            }
            //Submit unitList as a current selection
            Player.groups.SetSelection = gObjList;
        }
    }

    private void OnGUI()
    {
        if (m_selecting)
        {
            // Create a rect from both mouse positions
            var rect = Utils.GetScreenRect(m_startPointer, Input.mousePosition);
            Utils.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utils.DrawScreenRectBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    private Unit[] SelectableUnits
    {
        get
        {
            var foundUnits = FindObjectsOfType<Unit>();
            List<Unit> tempUnits = new List<Unit>();
            foreach (Unit i in foundUnits)
            {
                if (i.IsUnitSelectable)
                    tempUnits.Add(i);
            }
            return tempUnits.ToArray();
        }
    }

    public bool IsWithinSelectionBounds(GameObject gameObject)
    {
        if (m_selecting)
            return false;

        var camera = Camera.main;
        var viewportBounds = Utils.GetViewportBounds(camera, m_startPointer, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(gameObject.transform.position));
    }
}
