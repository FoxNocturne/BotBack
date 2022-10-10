using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionScene : BotBackManager {
    public Image transitionSceneImage;
    public string nameLevel;
    private float _color = 0f;
    private bool _activeTransition = false;
    private void Start()
    {
        this.transitionSceneImage.color = Color.clear;
    }

    private void Update()
    {
        this.transitionSceneImage.color = new Color(0, 0, 0, _color);
        if (this._activeTransition == true)
        {
            this._color += Time.deltaTime * 2;
        }
        else
        {
            this._color -= Time.deltaTime * 2;
        }
        this._color = Mathf.Clamp(this._color, 0f, 1f);
    }

    public void TransitionMomentTrigger() {
        StartCoroutine(TransitionMoment());
    }

    private IEnumerator TransitionMoment() {
        this._activeTransition = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameLevel);
    }
}
