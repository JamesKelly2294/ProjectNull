using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enumeration of the different possible states that the game can end in.
/// </summary>
public enum GameEndType
{
    /// <summary>
    /// The game was won.
    /// </summary>
    Win,

    /// <summary>
    /// The game was lost. 
    /// </summary>
    Loss
}

public abstract class BaseGameEnding : MonoBehaviour
{
    private bool HasRunGameEnding;

    /// <summary>
    /// The reason the game ended.
    /// </summary>
    public GameEndType EndType { get; }

    /// <summary>
    /// Run the end-game logic.
    /// </summary>
    public abstract void RunGameEnding();

    /// <summary>
    /// Determines whether or not this game ending is applicable.
    /// </summary>
    /// <returns>True if this game ending is applicable. False otherwise. </returns>
    public abstract bool IsGameEnd();

    // Start is called before the first frame update
    public void Start()
    {
        HasRunGameEnding = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (!HasRunGameEnding && IsGameEnd())
        {
            RunGameEnding();
            HasRunGameEnding = true;
        }
    }
}