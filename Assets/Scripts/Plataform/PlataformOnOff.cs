using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformOnOff : MonoBehaviour
{
    public string tagPlayer = "Player";

    public GameObject plataformOn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagPlayer))
        {
            StartCoroutine(PlataformCoroutine());
            //plataformOn.SetActive(true);
        }
    }

    IEnumerator PlataformCoroutine()
    {
        plataformOn.SetActive(true);
        yield return new WaitForSeconds(0.1f);

        yield return new WaitForSeconds(4);
        plataformOn.SetActive(false);
    }
}
