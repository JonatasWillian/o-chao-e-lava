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
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        StartCoroutine(PlataformOffCoroutine());
    }*/

    IEnumerator PlataformCoroutine()
    {
        plataformOn.SetActive(true);
        yield return new WaitForSeconds(5);

        plataformOn.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

    IEnumerator PlataformOffCoroutine()
    {
        plataformOn.SetActive(false);
        yield return new WaitForEndOfFrame();
    }
}
