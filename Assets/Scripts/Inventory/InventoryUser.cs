using UnityEngine;

namespace Codabra.Demo
{
    public class InventoryUser : InventoryOperator
    {
        [SerializeField]
        protected InventoryItem[] _inventory;
        [SerializeField]
        protected bool _getUsed;

        protected override bool Action(InventoryOwner owner)
        {
            return _getUsed
                ? owner.Use(_inventory)
                : owner.Check(_inventory);
        }
    }
}

