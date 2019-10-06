using UnityEngine;
using System.Collections;

/// <summary>
/// Game ending functionality for the lose state.
/// </summary>
public class PossumGameEndingLose : BaseGameEnding
{
    public GameObject triggerBounds;

    public override bool IsGameEnd()
    {
        TriggerGameEnd trigger = triggerBounds.GetComponent<TriggerGameEnd>();
        return trigger.WasTriggered() && trigger.GameEndType == GameEndType.Loss;
    }

    public override void RunGameEnding()
    {
        System.Console.WriteLine("lost");
    }
}
