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
    }

    [Serializable]
    public class Faction
    {
        public color color; //This might be redundant.
        public int lumber = 100;
        public int gold = 500;
        public int unitCount = 1;
        public int maxUnitCount = 5;
    }

    [Serializable]
    public class Unit
    {
        public string name;
        public int health;
        public int maxHealth;

        public Action OnDeath;

        public void TakeDamage(int value)
        {
            health -= value;
            if(health <= 0)
            {
                health = 0;
                OnDeath?.Invoke();
            }
        }
    }


}
