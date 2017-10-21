using System.Collections.Generic;
using UnityEngine;

namespace Codabra.Demo
{
    public class EquipHolder : MonoBehaviour
    {
        private Dictionary<string, int> equip = new Dictionary<string, int>();

        public void Get(EquipItem[] set)
        {
            foreach (var item in set)
                if (equip.ContainsKey(item.Name))
                    equip[item.Name] += item.Count;
                else equip.Add(item.Name, item.Count);
        }

        public bool Check(EquipItem[] set)
        {
            foreach (var item in set)
            {
                if (!equip.ContainsKey(item.Name)) return false;
                if (equip[item.Name] < item.Count) return false;
            }
            return true;
        }

        public bool Use(EquipItem[] set)
        {
            if (!Check(set)) return false;
            foreach (var item in set)
            {
                equip[item.Name] -= item.Count;
                if (equip[item.Name] <= 0) equip.Remove(item.Name);
            }
            return true;
        }
    }
}
