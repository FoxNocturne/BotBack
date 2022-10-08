using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCanvas : MonoBehaviour
{
    public static RobotCanvas InstantiateObject(GameObject prefab, Transform parent)
    {
        RobotCanvas instance = GameObject.Instantiate(prefab, parent).GetComponent<RobotCanvas>();
        instance.gameObject.SetActive(true);
        return instance;
    }
}
