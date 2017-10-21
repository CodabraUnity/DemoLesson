using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    private Animator anim;
    private CharacterController charController;
    private GameObject mainCamera;

    [Header("Скорость передвижения")]
    public float moveSpeed;
    [Header("Сила прыжка"), Range(1, 5)]
    public float jumpPower;

    [HideInInspector]
    public float jumpTime;
    [HideInInspector]
    public float gravityMultiplier = 0.8f;
    [HideInInspector]
    public float raycastDownLength = 0.5f;

    [Space]
    public bool isKeyGotten = false;

    private bool isChild = false;
    private bool onGround = true;

    private Vector3 playerTargetRotation;
    private Vector3 lastPlayerDirection;

    private void Update()
    {
        Move();
    }

    private void Move()
    { 
        CheckOnGround();

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(vertical) > 0.1f || Mathf.Abs(horizontal) > 0.1f)
        {
            RotatePlayer();
            MovePlayer();
        }
        else
        {
            transform.localEulerAngles = lastPlayerDirection;
            anim.SetInteger("MoveInt", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            Jump();
            return;
        }

        MoveByGravity();
        
    }

    private void Start()
    {
        mainCamera = Camera.main.gameObject;
        charController = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    private IEnumerator JumpRoutine(float jumpTimeCopy, float jumpPowerCopy)
    {
        onGround = false;
        anim.SetTrigger("Jump");
        anim.SetBool("OnGround", false);

        while (jumpTimeCopy >= 0)
        {
            charController.Move(-Physics.gravity * jumpPowerCopy * jumpTimeCopy * Time.deltaTime);
            jumpTimeCopy -= Time.deltaTime;
            yield return null;
        }

        anim.SetBool("OnGround", true);
        onGround = true;
    }

    private void CheckOnGround()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out hit, raycastDownLength))
        {
            onGround = true;
            anim.SetBool("OnGround", true);

            MovingStoneScript mss = null;

            if (hit.transform.parent)
                mss = hit.transform.parent.GetComponent<MovingStoneScript>();

            if (mss && mss.isActiveAndEnabled && !isChild)
            {
                Vector3 position = transform.position;
                Quaternion rotation = transform.rotation;
                Vector3 localScale = transform.localScale;

                transform.SetParent(mss.transform, false);

                transform.position = position;
                transform.rotation = rotation;
                transform.localScale = localScale;

                isChild = true;
            }
        }
        else
        {
            if (isChild)
            {
                isChild = false;
                Detach();
            }

            onGround = false;
            anim.SetBool("OnGround", false);
        }
    }

    private void Detach()
    {
        transform.parent = null;
    }

    private void MoveByGravity()
    {
        charController.Move(Physics.gravity * Time.deltaTime * gravityMultiplier);
    }

    private void Jump()
    {
        StartCoroutine(JumpRoutine(jumpTime, jumpPower));
    }

    void MovePlayer()
    {
        charController.Move(transform.forward * Time.deltaTime * moveSpeed);
        anim.SetInteger("MoveInt", 1);
    }

    void RotatePlayer()
    {
        Quaternion lookRot;
        lookRot = Quaternion.LookRotation(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        playerTargetRotation = lookRot.eulerAngles;

        playerTargetRotation += new Vector3(0, mainCamera.transform.rotation.eulerAngles.y, 0);

        gameObject.transform.rotation =
            Quaternion.Lerp(Quaternion.Euler(gameObject.transform.eulerAngles), Quaternion.Euler(playerTargetRotation), 20 * Time.deltaTime);
        lastPlayerDirection = gameObject.transform.localEulerAngles;
    }

}