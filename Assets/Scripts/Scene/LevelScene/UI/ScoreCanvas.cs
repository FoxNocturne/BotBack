using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] private Text _labelText;
    [SerializeField] private Text _valueText;

    private int _displayedScore;
    private int _trueScore;
    private bool _isChangingScore;
    public PlayerControler game;
    private List<int> _listGap = new List<int>() { 1000, 500, 100, 50, 10, 5, 1 };

    void Update()
    {
        SetValue(game.botpassed);
    }
    public void SetValue(int value)
    {
        this._trueScore = value;
        if (!this._isChangingScore) StartCoroutine(this.RunScoreAnimation());
    }

    public IEnumerator RunScoreAnimation()
    {
        this._isChangingScore = true;
        while (this._displayedScore != this._trueScore) {
            int variation = this._trueScore - this._displayedScore;
            foreach (var gap in this._listGap) {
                if (variation > gap) { this._displayedScore += gap; break; }
            }
            if (this._displayedScore > this._trueScore) { this._displayedScore = this._trueScore; }
            this._valueText.text = this._displayedScore.ToString();
            yield return new WaitForSeconds(0.05f);
        }
        this._isChangingScore = false;
    }
}
