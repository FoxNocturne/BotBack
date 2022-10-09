using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : BotBackManager {

    public Image imageGameOver;
    private float _color;
    private bool _activeTransition = false;
    private void Start()
    {
        this.imageGameOver.color = Color.black;
        StartCoroutine(this.GameOverTime());
    }

    private void Update()
    {
        this.imageGameOver.color = new Color(_color, _color, _color, 1);
        if(this._activeTransition == true) {
            this._color += Time.deltaTime;
        }
        else {
            this._color -= Time.deltaTime;
        }
        this._color = Mathf.Clamp(this._color, 0f, 1f);
    }

    private IEnumerator GameOverTime()
    {
        this._activeTransition = true;
        yield return new WaitForSeconds(4f);
        this._activeTransition = false;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
