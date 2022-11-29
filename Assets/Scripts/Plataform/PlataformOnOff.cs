using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformOnOff : MonoBehaviour
{
    public string tagPlayer = "Player";

    public GameObject plataformOn;

    public bool _disableOnStart = true;

    public float durationPlataform = 5f;

    private Collider[] colliders;
    private MeshRenderer meshRenderer;
    private PlataformOnOff plataformOnOff;

    public void Start()
    {
        colliders = GetComponents<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        plataformOnOff = plataformOn.GetComponent<PlataformOnOff>();
        if (_disableOnStart)
        {
            SetPlataformEnable(false);
        }
    }

    public void SetPlataformEnable(bool enabled)
    {
        for (int i = 0; i < colliders.Length; ++i)
        {
            colliders[i].enabled = enabled;
        }
        meshRenderer.enabled = enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tagPlayer))
        {
            StartCoroutine(PlataformCoroutine());
        }
    }

    IEnumerator PlataformCoroutine()
    {
        plataformOnOff.SetPlataformEnable(true);
        yield return new WaitForSeconds(durationPlataform);

        plataformOnOff.SetPlataformEnable(false);
        yield return new WaitForEndOfFrame();
    }
}
