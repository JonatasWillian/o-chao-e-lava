using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCameraTower : MonoBehaviour
{
    public string tagPlayer = "Player";

    public GameObject towerCamera;
    public Color gizColor = Color.yellow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagPlayer)
        {
            TurnCameraOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TurnCameraOff();
    }

    private void TurnCameraOn()
    {
        towerCamera.SetActive(true);
    }

    private void TurnCameraOff()
    {
        towerCamera.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = gizColor;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }
}
