using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayHelper : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.P;
    public AudioSource audioSource;
    public CharacterController characterController;

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Play();
        }
    }

    public void Play()
    {
        if (characterController.isGrounded)
        {
            audioSource.Play();
        }
    }
}
