using UnityEngine;
using UnityEngine.Events;

namespace Codabra.Demo
{
    public class InventoryUser : MonoBehaviour
    {
        [SerializeField]
        private InventoryItem[] _equip;
        [SerializeField]
        private bool _getUsed;
        [SerializeField]
        private int _reuseCount = 1;
        [SerializeField]
        private float _reuseTime = 0f;
        [SerializeField]
        private bool _destroyAfterUse;
        private float _lastUse = float.MinValue;
        public UnityEvent Activation = new UnityEvent();

        void OnTriggerEnter(Collider other)
        {
            if (Time.unscaledTime - _lastUse < _reuseTime || _reuseCount == 0) return;
            var holder = other.GetComponent<InventoryOwner>();
            if (holder == null) return;
            if (!(_getUsed ? holder.Use(_equip) : holder.Check(_equip))) return;
			Activation.Invoke();
            _reuseCount--;
            if (_reuseCount == 0 && _destroyAfterUse)
                Destroy(gameObject);
            else _lastUse = Time.unscaledTime;
        }
    }
}
