using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject virtualCamera;

    [SerializeField]
    VirtualCamerasCollection virtualCamerasCollection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player") && !virtualCamera.activeSelf)
        {
            virtualCamerasCollection.DeactivateAllCameras();
            virtualCamera.SetActive(true);
        }
    }
}
