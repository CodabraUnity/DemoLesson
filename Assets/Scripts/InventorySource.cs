using UnityEngine;

namespace Codabra.Demo
{
    public class InventorySource : MonoBehaviour
    {
        [SerializeField]
        private InventoryItem[] _equip;
        [SerializeField]
        private int _reuseCount = 1;
        [SerializeField]
        private float _reuseTime = 0f;
        [SerializeField]
        private bool _destroyAfterUse;
        private float _lastUse = float.MinValue;

        void OnTriggerEnter(Collider other)
        {
            if (Time.unscaledTime - _lastUse < _reuseTime || _reuseCount == 0) return;
            var holder = other.GetComponent<InventoryOwner>();
            if (holder == null) return;
            holder.Get(_equip);
            _reuseCount--;
            if (_reuseCount == 0 && _destroyAfterUse)
                Destroy(gameObject);
            else _lastUse = Time.unscaledTime;
        }
    }
}