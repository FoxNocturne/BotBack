using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUIPauseCanvas : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Text _subtitleText;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private CanvasGroup _pauseMenuGroup;

    public UnityEvent onRestart { get; } = new UnityEvent();
    public UnityEvent onQuit { get; } = new UnityEvent();
    public UnityEvent<bool> onToggle { get; } = new UnityEvent<bool>();
    public bool isOpen { get; private set; } = false;

    void Awake()
    {
        this.Close();
    }

    /// <summary>
    /// Trigerred when player clicks on pause button.
    /// Open pause menu canvas.
    /// </summary>
    public void Open()
    {
        this.onToggle.Invoke(true);
        Time.timeScale = 0;

        this._pauseButton.interactable = false;
        this._pauseButton.gameObject.SetActive(false);

        this._pauseMenuGroup.alpha = 1;
        this._pauseMenuGroup.interactable = true;
        this._pauseMenuGroup.blocksRaycasts = true;
        this._pauseMenuGroup.gameObject.SetActive(true);
    }

    /// <summary>
    /// Trigerred when player selects an action from the pause menu.
    /// Close pause menu canvas.
    /// </summary>
    public void Close()
    {
        this._pauseButton.interactable = true;
        this._pauseButton.gameObject.SetActive(true);

        this._pauseMenuGroup.alpha = 0;
        this._pauseMenuGroup.interactable = false;
        this._pauseMenuGroup.blocksRaycasts = false;
        this._pauseMenuGroup.gameObject.SetActive(false);

        Time.timeScale = 1;
        this.onToggle.Invoke(false);
    }

    /// <summary>
    /// Trigerred when player clicks on 'Resume' button.
    /// Close this pause ui.
    /// </summary>
    public void ResumeLevel()
    {
        this.Close();
    }

    /// <summary>
    /// Trigerred when player clicks on 'Restart' button.
    /// Reload the level scene.
    /// </summary>
    public void RestartLevel()
    {
        this.onRestart.Invoke();
        this.Close();
    }

    /// <summary>
    /// Triggered when player clicks on 'Quit' button.
    /// Quit level and go to main menu scene.
    /// </summary>
    public void QuitLevel()
    {
        this.onQuit.Invoke();
        this.Close();
    }

    // ===== Getter / Setter

    public string subtitle
    {
        get { return this._subtitleText.text; }
        set { this._subtitleText.text = value; }
    }

}
