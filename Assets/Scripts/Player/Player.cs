using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;

    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var axisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * axisVertical * speed;

        characterController.Move(speedVector * Time.deltaTime);
    }
}
