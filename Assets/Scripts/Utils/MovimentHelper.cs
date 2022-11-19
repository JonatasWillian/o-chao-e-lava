using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1f;

    private int _index = 0;

    private void Start()
    {
        StartCoroutine(StartMovimentCoroutine());
    }

    IEnumerator StartMovimentCoroutine()
    {
        float time = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (time / duration));

                time += Time.deltaTime;
                yield return null;
            }

            _index++;

            if (_index >= positions.Count) _index = 0;
            time = 0;

            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrou");
        if (!other.CompareTag("Player")) return;
        other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu");
        if (!other.CompareTag("Player")) return;
        other.transform.parent = null;
    }
}
