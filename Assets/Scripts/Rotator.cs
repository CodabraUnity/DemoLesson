using UnityEngine;

namespace Codabra.Demo
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private Vector3 rotation;

        void Update()
        {
            transform.Rotate(rotation);
        }
    }
}
