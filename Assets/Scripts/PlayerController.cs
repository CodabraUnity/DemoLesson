using System.Collections;
using UnityEngine;

namespace Codabra.Demo
{
    public class PlayerController : MonoBehaviour
    {
        private Animator _animator;
        private CharacterController _controller;
        private GameObject _mainCam;
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private float _jumpPower;
        [SerializeField]
        private float _gravity;

        public bool OnGround { get { return GetComponent<IGroundDetector>().OnGround; } }

        void Start()
        {
            _mainCam = Camera.main.gameObject;
            _controller = gameObject.GetComponent<CharacterController>();
            _animator = gameObject.GetComponent<Animator>();
        }

        void Update()
        {
            _animator.SetBool("OnGround", OnGround);
            var move = Physics.gravity;
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (direction.magnitude > 0.1f)
            {
                var target = Quaternion.LookRotation(direction).eulerAngles;
                target.y += _mainCam.transform.rotation.eulerAngles.y;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(target), 0.8f);
                move += transform.forward * _moveSpeed;
                _animator.SetBool("Move", true);
            }
            else _animator.SetBool("Move", false);
            _controller.Move(move * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
                StartCoroutine(JumpRoutine(_jumpPower));
        }

        IEnumerator JumpRoutine(float power)
        {
            _animator.SetTrigger("Jump");
            while (power >= 0)
            {
                _controller.Move(Vector3.up * power * 0.1f);
                power -= _gravity;
                yield return null;
            }
            yield break;
        }
    }
}
