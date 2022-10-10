using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotMarkerObject : MonoBehaviour
{
    [Header("GUI Components")]
    [SerializeField] private Image _pointerImage;
    [SerializeField] private Text _orderText;
    [SerializeField] private Animator _animator;

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _deselectedColor;

    void Awake()
    {
        this.SetSelected(false);
    }

    public void SetOrder(int value)
    {
        this._orderText.text = value.ToString();
    }

    public void SetSelected(bool isSelected) {
        this._pointerImage.color = isSelected ? this._selectedColor : this._deselectedColor;
        this._orderText.color = isSelected ? this._selectedColor : this._deselectedColor;
    }
}
