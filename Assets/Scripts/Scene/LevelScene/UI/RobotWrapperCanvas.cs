using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWrapperCanvas : MonoBehaviour
{
    [SerializeField] private RobotCanvas iconTemplate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) RobotCanvas.InstantiateObject(this.iconTemplate.gameObject, this.transform);
    }
}
