using UnityEngine;

namespace Codabra.Demo
{
    public class PlatformDetectorTrigger : MonoBehaviour
    {
        internal PlatformMover Mover;

        void Start()
        {
            transform.localPosition = Vector3.zero;
            transform.localEulerAngles = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.Translate(Vector3.up * 0.5f, Space.World);
            var mesh = GetComponent<MeshCollider>();
            mesh.convex = true;
            mesh.isTrigger = true;
        }

        void OnTriggerEnter(Collider other)
        {
            var follower = other.GetComponent<PlatformFollower>();
            if (follower != null)
                follower.Attach(this);
        }

        void OnTriggerExit(Collider other)
        {
            var follower = other.GetComponent<PlatformFollower>();
            if (follower != null)
                follower.Detach(this);
        }
    }
}
