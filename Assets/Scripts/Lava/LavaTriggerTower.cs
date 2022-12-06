using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTriggerTower : MonoBehaviour
{
    public string compareTag = "Player";

    public Animator animatorLava;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            animatorLava.SetTrigger("Lava");
        }

        //animatorLava.SetTrigger("Lava");
    }
}
