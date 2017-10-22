using System.Collections.Generic;
using UnityEngine;

namespace Codabra.Demo
{
    public class InventoryOwner : MonoBehaviour
    {
        private Dictionary<string, int> _equip = new Dictionary<string, int>();

        public void Get(InventoryItem[] set)
        {
            foreach (var item in set)
                if (_equip.ContainsKey(item.Name))
                    _equip[item.Name] += item.Count;
                else _equip.Add(item.Name, item.Count);
        }

        public bool Check(InventoryItem[] set)
        {
            foreach (var item in set)
            {
                if (!_equip.ContainsKey(item.Name)) return false;
                if (_equip[item.Name] < item.Count) return false;
            }
            return true;
        }

        public bool Use(InventoryItem[] set)
        {
            if (!Check(set)) return false;
            foreach (var item in set)
            {
                _equip[item.Name] -= item.Count;
                if (_equip[item.Name] <= 0) _equip.Remove(item.Name);
            }
            return true;
        }
    }
}
