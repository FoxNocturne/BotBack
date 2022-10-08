using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotBackManager : MonoBehaviour
{
    static public Cam CAM;
    static public Robot ROBOT;

    public Cam cam { get { return CAM; } private set { } }
    public Robot robot { get { return ROBOT; } private set { } }

    private void Awake()
    {
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (CAM == null)
            {
                CAM = g.GetComponentInChildren<Cam>(true);
            }

            if (ROBOT == null)
            {
                ROBOT = g.GetComponentInChildren<Robot>(true);
            }
        }
    }
}
