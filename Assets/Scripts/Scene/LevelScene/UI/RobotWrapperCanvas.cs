using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWrapperCanvas : MonoBehaviour
{
    [SerializeField] private RobotCanvas iconTemplate;
    private List<RobotCanvas> _listCanvas;

    public RobotCanvas AddRobot(Robot robot)
    {
        var newIcon = RobotCanvas.InstantiateObject(this.iconTemplate.gameObject, this.transform, robot);
        this._listCanvas.Add(newIcon);
        return newIcon;
    }

    public void Clear()
    {
        foreach (var canvas in this._listCanvas) {
            Destroy(canvas);
        }
        this._listCanvas.Clear();
    }
}
