using UnityEngine;

namespace Codabra.Demo
{
    public class PlatformDetector : MonoBehaviour
    {
        void Start()
        {
            var mesh = GetComponent<MeshFilter>();
            if (mesh != null)
            {
                var detector = new GameObject("StoneDetector", typeof(PlatformDetectorTrigger), typeof(MeshCollider));
                detector.transform.parent = transform;
                detector.GetComponent<PlatformDetectorTrigger>().Mover = GetComponent<PlatformMover>();
                detector.GetComponent<MeshCollider>().sharedMesh = mesh.mesh;
            }

        }
    }
}