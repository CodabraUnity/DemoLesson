using UnityEngine;

namespace Codabra.Demo
{
    public class PlatformFollower : MonoBehaviour, IGroundDetector
    {
        private CharacterController _character;
        private PlatformDetectorTrigger _platform;
        public bool OnGround { get { return _platform != null; } }

        internal void Attach(PlatformDetectorTrigger platform)
        {
            _platform = platform;
        }

        internal void Detach(PlatformDetectorTrigger platform)
        {
            if (_platform == platform)
                _platform = null;
        }

        void Start()
        {
            _character = GetComponent<CharacterController>();
            if (_character == null && GetComponent<Rigidbody>() == null)
            {
                var body = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
                body.useGravity = false;
                body.isKinematic = true;
            }
        }

        void Update()
        {
            if (_platform != null)
                if (_platform.mover != null)
                    if (_character != null)
                        _character.Move(_platform.mover.Speed * Time.deltaTime);
                    else
                        transform.Translate(_platform.mover.Speed * Time.deltaTime, Space.World);
        }
    }
}