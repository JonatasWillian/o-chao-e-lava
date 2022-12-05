using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public GameObject particle;
    public int key = 01;
    public GameObject text;

    private bool checkPointActived = false;
    private string checkPointKey = "CheckPointKey";

    private void OnTriggerEnter(Collider other)
    {
        if (!checkPointActived && other.transform.tag == "Player")
        {
            CheckPoint();
        }
    }

    private void CheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        particle.SetActive(true);
    }

    private void SaveCheckPoint()
    {
        CheckPointManager.Instance.SaveCheckPoint(key);

        checkPointActived = true;

        StartCoroutine(CheckPointCoroutine());
    }

    IEnumerator CheckPointCoroutine()
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(.5f);
        text.gameObject.SetActive(false);

        //checkPointCoroutine = null;
    }
}
