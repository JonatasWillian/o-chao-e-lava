using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBase : MonoBehaviour
{
    public string compareTag = "Player";

    public HealthBase healthBase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(compareTag))
        {
            healthBase.Damage();
        }
    }
}
