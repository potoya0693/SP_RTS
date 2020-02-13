using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RTS
{
    [Serializable]
    public class Unit : MonoBehaviour
    {
        public new string name;
        public color color;
        int _health;
        public int health;

        public Action OnDeath;

        private void Start()
        {
            _health = health;    
        }

        public bool IsUnitSelectable
        {
            get
            {
                if (color == Player.faction.color)
                    return true;
                else
                    return false;
            }
        }

        

        public void TakeDamage(int value)
        {
            _health -= value;
            if (_health <= 0)
            {
                _health = 0;
                OnDeath?.Invoke();
            }
            else if (_health >= health)
                _health = health;
        }
    }
}