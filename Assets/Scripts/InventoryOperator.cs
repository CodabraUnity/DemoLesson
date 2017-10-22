using UnityEngine;
using UnityEngine.Events;

namespace Codabra.Demo
{
    public abstract class InventoryOperator : MonoBehaviour
    {
        [SerializeField]
        protected int _reuseCount = 1;
        [SerializeField]
        protected float _reuseTime = 0f;
        [SerializeField]
        protected bool _destroyAfterUse;
        private float _lastUse = float.MinValue;
        public UnityEvent Activation = new UnityEvent();

		protected abstract bool Action(InventoryOwner owner);

        void OnTriggerEnter(Collider other)
        {
            if (Time.unscaledTime - _lastUse < _reuseTime || _reuseCount == 0) return;
            var owner = other.GetComponent<InventoryOwner>();
            if (owner == null) return;
            if(!Action(owner)) return;
			Activation.Invoke();
            _reuseCount--;
            if (_reuseCount == 0 && _destroyAfterUse)
                Destroy(gameObject);
            else _lastUse = Time.unscaledTime;
        }
    }
}
