using UnityEngine;
using System.Collections;

/// <summary>
/// Game ending functionality for the win state.
/// </summary>
public class PossumGameEndingVictory : BaseGameEnding
{
    public GameObject particleEmitter;
    public GameObject triggerBounds;

    public override bool IsGameEnd()
    {
        TriggerGameEnd trigger = triggerBounds.GetComponent<TriggerGameEnd>();
        return trigger.WasTriggered() && trigger.GameEndType == GameEndType.Win;
    }

    public override void RunGameEnding()
    {
        System.Console.WriteLine("won");

        var pedestal = particleEmitter.GetComponent<Pedestal>();
        pedestal.PlayParticleEffects();
    }
}
