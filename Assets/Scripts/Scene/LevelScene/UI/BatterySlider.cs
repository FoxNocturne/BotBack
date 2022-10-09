using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BatterySlider : MonoBehaviour
{
    [Header("Slider Setting")]
    [SerializeField] private Slider _slider;

    [Header("Border Setting")]
    [SerializeField] private Image _boderImage;
    [SerializeField] private Color _normalColor;
    [SerializeField] private Color _alertColor;
    [SerializeField] private float _alertThreshold;

    [Header("Filler Setting")]
    [SerializeField] private Gradient _colorGradient;
    [SerializeField] private Image _fillerImage;

    public Timer timer { get; protected set; }
    private bool isLowBatteryAnimated = false;

    void Awake()
    {
        this.ChangeFillerColor();
    }

    public void SetMaxValue(float value)
    {
        this._slider.maxValue = value;
    }

    public void SetValue(float value)
    {
        this._slider.value = Mathf.Max(Mathf.Min(this._slider.maxValue, value), 0);
        this.ChangeFillerColor();
        if (this.IsUnderAlertThreshold() && !this.isLowBatteryAnimated) StartCoroutine(this.RunAlertAnimation());
    }

    public void ChangeFillerColor()
    {
        this._fillerImage.color = this._colorGradient.Evaluate((float)this._slider.value / (float)this._slider.maxValue);
    }

    private IEnumerator RunAlertAnimation()
    {
        this.isLowBatteryAnimated = true;
        while (this.IsUnderAlertThreshold()) {
            this._boderImage.color = this._alertColor;
            yield return new WaitForSeconds(0.08f);
            this._boderImage.color = this._normalColor;
            yield return new WaitForSeconds(0.08f);
        }
        this.isLowBatteryAnimated = false;
    }

    private bool IsUnderAlertThreshold()
    {
        return this._slider.value / this._slider.maxValue < this._alertThreshold;
    }
}
