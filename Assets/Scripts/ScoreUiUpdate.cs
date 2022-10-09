using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUiUpdate : BotBackManager
{
    private ScoreCanvas txt;
    public PlayerControler game;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<ScoreCanvas>();
    }

    // Update is called once per frame
    void Update()
    {
        txt.SetValue( game.botpassed );
    }
}
