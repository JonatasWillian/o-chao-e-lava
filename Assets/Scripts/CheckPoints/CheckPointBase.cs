using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public GameObject particle;
    public int key = 01;

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
        /*if(PlayerPrefs.GetInt(checkPointKey, 0) > key)
            PlayerPrefs.SetInt(checkPointKey, key);*/

        CheckPointManager.Instance.SaveCheckPoint(key);

        checkPointActived = true;
    }
}
