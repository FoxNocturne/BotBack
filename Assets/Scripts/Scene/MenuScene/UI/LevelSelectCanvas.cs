using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectCanvas : MonoBehaviour
{
    [Header("GUI Components")]
    [SerializeField] private GameObject _buttonTemplate;

    void Awake()
    {
        this.InstantiateButtons(4);
    }

    public List<LevelSelectButton> InstantiateButtons(int nbLevel) {
        List<LevelSelectButton> listButton = new List<LevelSelectButton>();
        for (int levelId = 1; levelId <= nbLevel; levelId++) {
            var button = LevelSelectButton.InstantiateObject(this._buttonTemplate, this.transform, levelId);
            button.onClick.AddListener(() => { this.GoToLevel(button.levelId); });
        }
        return listButton;
    }

    private void GoToLevel(int levelId)
    {
        GameManager.currentLevelId = levelId;
        SceneManager.LoadScene("LevelScene");
    }
}
