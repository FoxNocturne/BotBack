using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : BotBackManager {

    [SerializeField] private Canvas _mainMenuCanvas;
    [SerializeField] private Canvas _levelMenuCanvas;

    public void NavigateToLevelSelectMenu()
    {
        this._mainMenuCanvas.gameObject.SetActive(false);
        this._levelMenuCanvas.gameObject.SetActive(true);
    }

    public void NavigateToMainMenu()
    {
        this._mainMenuCanvas.gameObject.SetActive(true);
        this._levelMenuCanvas.gameObject.SetActive(false);
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void GoToGalerie()
    {
        SceneManager.LoadScene("GaleryScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
