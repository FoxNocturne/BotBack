using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : BotBackManager {
    public void PlayGame() {
        SceneManager.LoadScene("LevelScene 1");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
