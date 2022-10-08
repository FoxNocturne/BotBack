using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "VirtualCamerasAsset", menuName = "GameCustomAssets/Virtual Camera Library", order = 1)]
public class VirtualCamerasCollection : ScriptableObject
{
    private List<GameObject> virtualCameras = new List<GameObject>();

    public IReadOnlyCollection<GameObject> VirtualCameras => virtualCameras.AsReadOnly();

    public void RegisterCamera(GameObject virtualCamera)
    {
        virtualCameras.Add(virtualCamera);
    }

    public void DeactivateAllCameras()
    {
        virtualCameras.ForEach(camera => camera.SetActive(false));
    }
}
