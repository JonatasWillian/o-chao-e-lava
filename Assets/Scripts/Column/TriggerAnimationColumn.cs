using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationColumn : MonoBehaviour
{
    public string tagPlayer = "Player";

    public Animator animatorColumn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagPlayer))
        {
            animatorColumn.SetTrigger("Column");
        }
    }
}
