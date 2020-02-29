using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A list of game events that can potentially be called
public class GameEvents : MonoBehaviour
{
    
    public static GameEvents eventController;

    private void Awake()
    {
        eventController = this;
    }

    // Create an action that can be called
    public event Action<int,int> onGameScoreChange;
    
    // Game score change 
    public void GameScoreChange(int id, int value)
    {
        onGameScoreChange?.Invoke(id, value);
    }
}
