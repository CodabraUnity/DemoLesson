using System.Collections;
using UnityEngine;

namespace Codabra.Demo
{
    public class PlayerController : MonoBehaviour
    {
        private Animator animator;
        private CharacterController controller;
        private GameObject mainCam;
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float jumpPower;
        [SerializeField]
        private float gravity = 0.8f;

        public bool OnGround { get { return GetComponent<IGroundDetector>().OnGround; } }

        void Start()
        {
            mainCam = Camera.main.gameObject;
            controller = gameObject.GetComponent<CharacterController>();
            animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            animator.SetBool("OnGround", OnGround);
            var move = Physics.gravity;
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (direction.magnitude > 0.1f)
            {
                var target = Quaternion.LookRotation(direction).eulerAngles;
                target.y += mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), 0.8f);
                move += transform.forward * moveSpeed;
                animator.SetBool("Move", true);
            }
            else animator.SetBool("Move", false);
            controller.Move(move * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
                StartCoroutine(JumpRoutine(jumpPower));
        }

        IEnumerator JumpRoutine(float power)
        {
            animator.SetTrigger("Jump");
            while (power >= 0)
            {
                controller.Move(Vector3.up * power * 0.1f);
                power -= gravity;
                yield return null;
            }
            yield break;
        }
    }
}
