using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWrapperCanvas : MonoBehaviour
{
    [SerializeField] private RobotCanvas iconTemplate;
    private List<RobotCanvas> _listIcon = new List<RobotCanvas>();

    public RobotCanvas AddRobot(Robot robot)
    {
        var newIcon = RobotCanvas.InstantiateObject(this.iconTemplate.gameObject, this.transform, robot);
        robot.onGoal.AddListener(() => newIcon.PrintGoal());
        robot.onDeath.AddListener(() => newIcon.PrintDeath());
        this._listIcon.Add(newIcon);
        return newIcon;
    }

    public void Clear()
    {
        foreach (RobotCanvas icon in this._listIcon) {
            Destroy(icon);
        }
        this._listIcon.Clear();
    }
}
