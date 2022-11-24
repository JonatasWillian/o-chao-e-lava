using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformDisable : MonoBehaviour
{
    public GameObject plataformDisable;

    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(playerTag))
        {
            plataformDisable.SetActive(false);
        }
    }
}
