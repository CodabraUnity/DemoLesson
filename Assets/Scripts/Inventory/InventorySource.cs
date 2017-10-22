using UnityEngine;

namespace Codabra.Demo
{
    public class InventorySource : InventoryOperator
    {
        [SerializeField]
        protected InventoryItem[] _inventory;

        protected override bool Action(InventoryOwner owner)
        {
            owner.Get(_inventory);
            return true;
        }
    }
}