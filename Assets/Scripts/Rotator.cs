using UnityEngine;

namespace Codabra.Demo
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField]
        private Vector3 _rotation;

        void Update()
        {
            transform.Rotate(_rotation);
        }
    }
}
