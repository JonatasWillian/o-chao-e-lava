using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Animator")]
    public Animator animator;

    [Header("Status")]
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float jumpSpeed = 15f;
    public float gravit = -9.8f;
    public float speedRun = 1.5f;

    [Header("HealthBase")]
    public HealthBase healthBase;

    [Header("Screen")]
    public GameObject endScreen;

    private string tagTrigger = "End";

    private float vSpeed = 0;
    private bool _jumping = false;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            if (_jumping)
            {
                _jumping = false;
                animator.SetTrigger("Land");
            }

            vSpeed = 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;

                if (!_jumping)
                {
                    _jumping = true;
                    animator.SetTrigger("Jump");
                }
            }
        }

        var isWalking = inputAxisVertical != 0;

        if (isWalking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        vSpeed -= gravit * Time.deltaTime;
        speedVector.y = vSpeed;

        animator.SetBool("Run", isWalking);
    }

    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if (CheckPointManager.Instance.HasCheckPoint())
        {
            transform.position = CheckPointManager.Instance.GetPositionCheckPoint();
        }
    }

    private Vector3 speedVector;

    private Vector3 externalMovement = Vector3.zero;

    public void AddExternalMovement(Vector3 movement)
    {
        externalMovement += movement;
    }

    private void FixedUpdate()
    {
        characterController.Move(speedVector * Time.deltaTime + externalMovement);
        externalMovement = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagTrigger))
        {
            endScreen.SetActive(true);
            speed = 0;
        }
    }
}
