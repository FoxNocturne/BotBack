using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestClearSceneManager : MonoBehaviour
{
    [SerializeField] private Text _baseScoreValueText;
    [SerializeField] private Text _timeValueText;
    [SerializeField] private Text _robotSaveValueText;
    [SerializeField] private Text _noStopValueText;
    [SerializeField] private Text _totalScoreValueText;

    private static LevelScoreComputer _levelScoreComputer;

    public static void LoadScene(LevelScoreComputer computer)
    {
        QuestClearSceneManager._levelScoreComputer = computer;
        SceneManager.LoadScene("QuestClear");
    }

    public void Start()
    {
        if (QuestClearSceneManager._levelScoreComputer != null) {
            this._baseScoreValueText.text = QuestClearSceneManager._levelScoreComputer.baseScore.ToString();
            this._timeValueText.text = QuestClearSceneManager._levelScoreComputer.timeScore.ToString();
            this._robotSaveValueText.text = QuestClearSceneManager._levelScoreComputer.saveScore.ToString();
            this._noStopValueText.text = QuestClearSceneManager._levelScoreComputer.noStopScore.ToString();
            this._totalScoreValueText.text = QuestClearSceneManager._levelScoreComputer.totalScore.ToString();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}