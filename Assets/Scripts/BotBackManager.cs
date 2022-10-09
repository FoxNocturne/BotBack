using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotBackManager : MonoBehaviour
{
    static public Cam CAM;
    static public  Timer GlobalTimer = new Timer();
    public Cam cam { get { return CAM; } private set { } }

    private void Awake()
    {
        foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
        {
            if (CAM == null)
            {
                CAM = g.GetComponentInChildren<Cam>(true);
            }
        }
    }
}
