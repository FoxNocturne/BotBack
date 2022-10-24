using System.Collections;
using UnityEngine;

public class GadgetObjectCoin : GadgetObject
{
    [Header("Gadget Parameters")]
    [SerializeField] private int _coinScore;

    private bool _isCollected = false;

    void OnTriggerEnter(Collider other)
    {
        Robot robot = other.GetComponent<Robot>();
        if (robot != null && !this._isCollected) {
            LevelSceneManager.instance.levelScorer.IncreaseScorePrinted(this._coinScore, this.transform.position);
            this._isCollected = true;
            Destroy(this.gameObject);
        }
    }

    protected override void Setup()
    {
        this.isGrabable = false;
    }
}