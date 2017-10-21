using UnityEngine;

namespace Codabra.Demo
{
    public class PlatformMover : MonoBehaviour
    {
        [SerializeField]
        internal Vector3 Speed = Vector3.zero;
        [SerializeField]
        private float maxDistance;
        private Vector3 _startPosition;

        void Start()
        {
            _startPosition = transform.position;
        }

        void Update()
        {
            var distance = Vector3.Distance(transform.position + Speed * Time.deltaTime, _startPosition);
            if (distance < maxDistance && distance > Speed.magnitude * 0.01f)
                transform.Translate(Speed * Time.deltaTime, Space.World);
            else
                Speed *= -1;
        }
    }
}