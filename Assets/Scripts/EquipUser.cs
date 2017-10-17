using UnityEngine;
using UnityEngine.Events;

namespace Codabra.Demo
{
    public class EquipUser : MonoBehaviour
    {
        [SerializeField]
        private EquipItem[] equip;
        [SerializeField]
        private bool getUsed;
        [SerializeField]
        private int reuseCount = 1;
        [SerializeField]
        private float reuseTime = 0f;
        [SerializeField]
        private bool destroyAfterUse;
        private float lastUse = float.MinValue;
        public UnityEvent Activation = new UnityEvent();

        void OnTriggerEnter(Collider other)
        {
            if (Time.unscaledTime - lastUse < reuseTime || reuseCount == 0) return;
            var holder = other.GetComponent<EquipHolder>();
            if (holder == null) return;
            if (!(getUsed ? holder.Use(equip) : holder.Check(equip))) return;
			Activation.Invoke();
            reuseCount--;
            if (reuseCount == 0 && destroyAfterUse)
                Destroy(gameObject);
            else lastUse = Time.unscaledTime;
        }
    }
}
