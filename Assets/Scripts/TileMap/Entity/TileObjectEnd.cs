using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TileObjectEnd : TileObject
{
    [Header("Components")]
    [SerializeField] private Animator _textAnimator;
    [SerializeField] private Text _goalText;
    [SerializeField] private Text _scoreText;

    [Header("Tile Parameters")]
    [SerializeField] private int _goalScore;
    [SerializeField] private int _chainBonusFactor;
    [SerializeField] private float _baseChainDelay;

    private int _currentChainLength = 0;
    private float _currentChainDelay = 0;
    private bool _isChainOngoing = false;

    void Awake()
    {
        this._goalText.text = "";
        this._scoreText.text = "";
    }

    /// <summary>
    /// Setup tile's specific variables
    /// </summary>
    protected override void Setup()
    {
        this.isWalkable = true;
        this.isFlyable = true;
        this.isKill = false;
        this.isWin = true;
        this.isFire = false;
        this.isVoid = false;
        LevelSceneManager.instance.onLevelFinish.AddListener(() => {
            LevelSceneManager.instance.levelScorer.IncreaseScore(this.ComputeChainScore());
            this._isChainOngoing = false;
        });
    }

    /// <summary>
    /// Triggered when robot land on tile.
    /// Set robot as goal and increase score based on current chain length.
    /// </summary>
    /// <param name="robot"></param>
    public override void OnRobotLand(Robot robot)
    {
        this._currentChainLength++;
        this._goalText.text = this._currentChainLength > 1 ? "Chaîne x" + this._currentChainLength.ToString() + "!" : "Arrivée!";
        this._scoreText.text = this.ComputeChainScore().ToString();

        this._currentChainDelay = this._baseChainDelay;
        if (!this._isChainOngoing) { StartCoroutine(this.UpdateChainCooldown()); }

        robot.Goal();
    }

    private IEnumerator UpdateChainCooldown()
    {
        this._isChainOngoing = true;
        this._textAnimator.SetBool("isDisplayed", true);
        while (this._currentChainDelay > 0 && this._isChainOngoing) {
            this._currentChainDelay -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        this._currentChainDelay = 0;
        this._currentChainLength = 0;

        // Si _isChainOngoing est FALSE, alors le cooldown a été coupé par une fin de niveau et le score a déjà été pris en compte.
        if (this._isChainOngoing) {
            LevelSceneManager.instance.levelScorer.IncreaseScore(this.ComputeChainScore());
            this._isChainOngoing = false;
            this._textAnimator.SetBool("isDisplayed", false);
            this._goalText.text = "";
            this._scoreText.text = "";
        }
    }

    private int ComputeChainScore()
    {
        return this._goalScore * Mathf.RoundToInt(Mathf.Pow(this._chainBonusFactor, this._currentChainLength - 1));
    }
}
