using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCameraRegistration : MonoBehaviour
{
    [SerializeField]
    VirtualCamerasCollection virtualCamerasAsset;

    private void Start()
    {
        virtualCamerasAsset.RegisterCamera(gameObject);
    }
}
