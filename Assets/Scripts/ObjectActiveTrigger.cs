using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToTrigger;

    [SerializeField]
    private Sprite onSprite;

    [SerializeField]
    private Sprite offSprite;

    [SerializeField]
    private float idleTime = 0.5f;
    private SpriteRenderer _spriteRenderer;
    private float _lastTimeButtonWasPressed;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _lastTimeButtonWasPressed = Time.time;    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time - _lastTimeButtonWasPressed > idleTime)
        {
            _lastTimeButtonWasPressed = Time.time;
            objectToTrigger.SetActive(!objectToTrigger.activeSelf);
            _spriteRenderer.sprite = objectToTrigger.activeSelf ? onSprite : offSprite;
        }
    }
}
