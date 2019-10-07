using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HintDismissBehavior
{
    DismissAfterPresenting,
    DismissAfterTimeOut
}

public enum HintCadence
{
    // The hint should be shown once.
    once,

    // The hint should be shown a set number of times.
    upToMaxCount,

    // The hint should always be shown.
    always
}

public class Hint : MonoBehaviour
{

    /// <summary>
    /// If true, then the preconditions for showing the hint have been met.
    /// Triggers and other external scripts should set this to 
    /// </summary>
    public bool IsDisplayable { get; set; }

    /// <summary>
    /// If true, then the hint has been presented previously.
    /// </summary>
    public bool HasPresented { get; private set; }

    /// <summary>
    /// If true, than the hint is actively being displayed. Used for debouncing.
    /// </summary>
    public bool IsPresenting { get; set; }

    /// <summary>
    /// Controls how many times the hint should be displayed. Defaults to "once".
    /// </summary>
    public HintCadence cadence = HintCadence.once;

    /// <summary>
    /// The maximum number of times the hint should be displayed.
    /// </summary>
    public int MaxCount = 1;

    // How many times has the hint been presented?
    private int _presentations;

    /// <summary>
    /// Behavior for dismissing the hint. Defaults to a timeout, with the value specified in DismissTimeOut.
    /// </summary>
    public HintDismissBehavior DismissBehavior = HintDismissBehavior.DismissAfterTimeOut;

    /// <summary>
    /// The amount of time to wait before dismissing the timeout.
    /// </summary>
    public float DismissTimeout = 5.0f;

    /// <summary>
    /// The hint text to display to the user.
    /// </summary>
    public string HintText;

    /// <summary>
    /// If true, then a hint should be displayed.
    /// 1. The hint must have been actived by some other logic prior to this check.
    /// 2. If the hint candence is always, the hint will be shown.
    /// 3. If the hint cadence is once and the hint hasn't been shown previously, the hint will be shown.
    /// 4. If the hint candence is count and the hint has been presented the indicated number of times, the hint will be shown.
    /// </summary>
    public bool ShouldShowHint
    {
        get
        {
            bool showAlways = cadence == HintCadence.always;
            bool shownOnceButHasntPresented = cadence == HintCadence.once && !HasPresented;
            bool shownSetNumberOfTimes = cadence == HintCadence.upToMaxCount && _presentations < MaxCount;
            return IsDisplayable && (showAlways || shownOnceButHasntPresented || shownSetNumberOfTimes);
        }
    }

    private HintManager HintManager
    {
        get
        {
            return GameManager.Instance.GetComponent<HintManager>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HasPresented = false;
        IsDisplayable = false;
        _presentations = 0;
        _dismissDelta = 0.0f;
    }

    private float _dismissDelta;

    void Update()
    {
        if (!IsDisplayable && DismissBehavior == HintDismissBehavior.DismissAfterPresenting)
        {
            HintManager.DismissHint(this);
            IsPresenting = false;
        }

        if (IsDisplayable && DismissBehavior == HintDismissBehavior.DismissAfterTimeOut)
        {
            _dismissDelta += Time.deltaTime;
            if (_dismissDelta > DismissTimeout)
            {
                HintManager.DismissHint(this);
                IsDisplayable = false;
                IsPresenting = false;
                _dismissDelta = 0.0f;
            }
        }
    }

    /// <summary>
    /// Should be called after a hint has been shown.
    /// </summary>
    public void WasPresented()
    {
        HasPresented = true;
        _presentations += 1;
    }
}
