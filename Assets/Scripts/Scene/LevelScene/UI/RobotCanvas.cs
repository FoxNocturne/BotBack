using UnityEngine;
using UnityEngine.UI;

public class RobotCanvas : MonoBehaviour
{
    [Header("Robot Icon Setting")]
    [SerializeField] private Image _robotImage;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    [Header("Status Icon Settings")]
    [SerializeField] private Image _iconImage;
    [SerializeField] private Sprite _goalIcon;
    [SerializeField] private Color _goalIconColor;
    [SerializeField] private Sprite _deathIcon;
    [SerializeField] private Color _deathIconColor;

    public Robot robot;

    public static RobotCanvas InstantiateObject(GameObject prefab, Transform parent, Robot robot = null)
    {
        RobotCanvas instance = GameObject.Instantiate(prefab, parent).GetComponent<RobotCanvas>();
        instance.PrintActive();
        instance.robot = robot;
        robot.onDeath.AddListener(() => { instance.PrintDeath(); });
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void PrintActive()
    {
        this._robotImage.color = this._activeColor;
        this._iconImage.enabled = false;
    }

    public void PrintDeath()
    {
        this._robotImage.color = this._inactiveColor;
        this._iconImage.sprite = this._goalIcon;
        this._iconImage.color = this._goalIconColor;
        this._iconImage.enabled = true;
    }

    public void PrintGoal()
    {
        this._robotImage.color = this._inactiveColor;
        this._iconImage.sprite = this._deathIcon;
        this._iconImage.color = this._deathIconColor;
        this._iconImage.enabled = true;
    }
}
