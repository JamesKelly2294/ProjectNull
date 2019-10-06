using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Default constructor to private due to this being a Singleton.
    /// </summary>
    private GameManager() {}

    /// <summary>
    /// Lazily-initialized singleton instance of the game manager.
    /// </summary>
    private GameManager _instance;

    /// <summary>
    /// Singleton instance of the game manager.
    /// </summary>
    public GameManager Instance
    {
        get {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
