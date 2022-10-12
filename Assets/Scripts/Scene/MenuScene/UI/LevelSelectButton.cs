using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelSelectButton : MonoBehaviour
{
    [Header("GUI Components")]
    [SerializeField] private Button _button;
    [SerializeField] private Text _labelText;

    public UnityEvent onClick = new UnityEvent();
    public int levelId { get; private set; }

    public static LevelSelectButton InstantiateObject(GameObject prefab, Transform parent, int levelId)
    {
        LevelSelectButton instance = GameObject.Instantiate(prefab, parent).GetComponent<LevelSelectButton>();
        instance.levelId = levelId;
        instance._labelText.text = levelId.ToString();
        instance._button.onClick.AddListener(() => instance.onClick.Invoke());
        instance.gameObject.SetActive(true);
        return instance;
    }
}
