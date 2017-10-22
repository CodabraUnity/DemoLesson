using System.Collections.Generic;
using UnityEngine;

namespace Codabra.Demo
{
    public class InventoryOwner : MonoBehaviour
    {
        private Dictionary<string, int> _inventory = new Dictionary<string, int>();

        public void Get(InventoryItem[] set)
        {
            foreach (var item in set)
                if (_inventory.ContainsKey(item.Name))
                    _inventory[item.Name] += item.Count;
                else _inventory.Add(item.Name, item.Count);
        }

        public bool Check(InventoryItem[] set)
        {
            foreach (var item in set)
            {
                if (!_inventory.ContainsKey(item.Name)) return false;
                if (_inventory[item.Name] < item.Count) return false;
            }
            return true;
        }

        public bool Use(InventoryItem[] set)
        {
            if (!Check(set)) return false;
            foreach (var item in set)
            {
                _inventory[item.Name] -= item.Count;
                if (_inventory[item.Name] <= 0) _inventory.Remove(item.Name);
            }
            return true;
        }
    }
}
