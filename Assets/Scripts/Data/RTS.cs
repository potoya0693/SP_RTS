using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RTS
{

    public enum color { Red, Blue, Green }

    public static class Player
    {
        public static Faction faction;
        public static ObjectGroups groups = new ObjectGroups();
    }

    [Serializable]
    public class ObjectGroups
    {
        List<GameObject> _currentSelection = new List<GameObject>();
        List<GameObject> _group1 = new List<GameObject>();
        List<GameObject> _group2 = new List<GameObject>();
        List<GameObject> _group3 = new List<GameObject>();

        int _maxSelection = 8;

        public List<GameObject> SetSelection
        {
            set
            {
                if (value.Count <= 8)
                    _currentSelection = value;
                else
                    _currentSelection = null;
            }
        }

        public void AddtoGroup(List<GameObject> from, List<GameObject> to)
        {
            int count = 0;

            if (from.Count + to.Count <= _maxSelection)
            {
                to.AddRange(from);
            }
            else
            {
                count = from.Count - to.Count;
                if (count < 0)
                    count *= -1;
                from.RemoveRange(from.Count - 1, count);
                to.AddRange(from);
            }
        }

        public List<GameObject> GetGroup(int index)
        {
            if (index == 0)
                return _currentSelection;
            else if (index == 1)
                return _group1;
            else if (index == 2)
                return _group2;
            else if (index == 3)
                return _group3;
            else
                return null;
        }

        public void SelectionToGroup(int index)
        {
            var groupNum = GetGroup(index);
            groupNum = _currentSelection;
        }

        public void SelectGroup(int index)
        {
            var groupNum = GetGroup(index);
            _currentSelection = groupNum;
        }

        public bool Exists(GameObject i)
        {
            if (_currentSelection.Exists(x => x == i))
                return true;
            else
                return false;
        }

    }

    [Serializable]
    public class Faction
    {
        public color color; //This might be redundant.
        public int lumber = 100;
        public int gold = 500;
        public int unitCount = 0;
        public int maxUnitCount = 5;
    }




}
