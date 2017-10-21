using UnityEngine;

namespace Codabra.Demo
{
    public class EquipGiver : MonoBehaviour
    {
        [SerializeField]
        private EquipItem[] equip;
        [SerializeField]
        private int reuseCount = 1;
        [SerializeField]
        private float reuseTime = 0f;
        [SerializeField]
        private bool destroyAfterUse;
        private float lastUse = float.MinValue;

        void OnTriggerEnter(Collider other)
        {
            if (Time.unscaledTime - lastUse < reuseTime || reuseCount == 0) return;
            var holder = other.GetComponent<EquipHolder>();
            if (holder == null) return;
            holder.Get(equip);
            reuseCount--;
            if (reuseCount == 0 && destroyAfterUse)
                Destroy(gameObject);
            else lastUse = Time.unscaledTime;
        }
    }
}