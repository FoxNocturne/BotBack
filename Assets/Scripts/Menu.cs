using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : BotBackManager {

    public GameObject layoutPlayExit;
    public GameObject layoutLevel;
    public void PlayGame() {
        this.layoutPlayExit.SetActive(false);
        this.layoutLevel.SetActive(true);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("LevelScene 1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level");
    }
}
