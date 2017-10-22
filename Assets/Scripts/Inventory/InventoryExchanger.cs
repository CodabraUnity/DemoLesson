using UnityEngine;

namespace Codabra.Demo
{
    public class InventoryExchanger : InventoryOperator
    {

        [SerializeField]
        protected InventoryItem[] _inputInventory;
        [SerializeField]
        protected InventoryItem[] _outputInventory;
        [SerializeField]
        protected bool _getUsed;

        protected override bool Action(InventoryOwner owner)
        {
            if (_getUsed ? owner.Use(_inputInventory) : owner.Check(_inputInventory))
			{
				owner.Get(_outputInventory);
				return true;
			}
			else return false;
        }
    }
}