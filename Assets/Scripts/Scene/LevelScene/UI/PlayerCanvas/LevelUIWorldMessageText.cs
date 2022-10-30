using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIWorldMessageText : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Text _valueText;

    [Header("Parameters")]
    [SerializeField] private float _lifetime;

    public static LevelUIWorldMessageText InstantiateObject(GameObject prefab, Transform parent, string scoreText, Vector3 worldPosition)
    {
        LevelUIWorldMessageText instance = GameObject.Instantiate(prefab, parent).GetComponent<LevelUIWorldMessageText>();
        instance._valueText.text = scoreText;
        Vector2 size = instance._rectTransform.rect.size;
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
        instance._rectTransform.offsetMin = screenPosition - (size / 2);
        instance._rectTransform.offsetMax = screenPosition + (size / 2);
        instance.gameObject.SetActive(true);
        instance.StartCoroutine(instance.DestroySelf());
        return instance;
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(this._lifetime / 1000f);
        Destroy(this.gameObject);
    }
}
