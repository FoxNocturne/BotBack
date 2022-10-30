using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIWorldMessageCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _textTemplate;

    public void PrintScore(int value, Vector3 worldPosition)
    {
        LevelUIWorldMessageText.InstantiateObject(this._textTemplate, this.transform, value.ToString(), worldPosition);
    }

    public void PrintGoal(int chainLength, int scoreValue, Vector3 worldPosition)
    {

    }
}
