using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField]
    private MatchState matchState;
    [SerializeField]
    private Dictionary<int, int> registeredScores;
    [SerializeField]
    private Dictionary<int, GameObject> registeredPlayers;

    private void Awake()
    {
        matchState = FindObjectOfType<MatchState>();

        
    }

    private void Start()
    {
        registeredScores = new Dictionary<int, int>();
        registeredPlayers = matchState.RegisteredPlayers;
        DontDestroyOnLoad(transform.parent.gameObject);

        GameEvents.eventController.onGameScoreChange += OnGameScoreChange;

        // Subscribe to listen to the game score change 
    }

    // Checks for the OnGameScoreChange being called
    private void OnGameScoreChange(int id, int value)
    {
        registeredScores[id] = registeredScores[id] + value;
        Debug.Log("Player " + id + "'s game score changed by: " + value);
    }

    // Gets the player score from the ID
    public int GetScoreById(int id)
    {
        return registeredScores[id];
    }

    // Gets the score based on the object
    // -1 indicates the GameObject can't be found
    public int GetScoreByObject(GameObject o)
    {
        for (int id = 0; id < registeredPlayers.Count; id++)
        {
            if (registeredPlayers[id] == o)
                return registeredScores[id];
        }
        return -1;
    }

    public void RegisterPlayer(int id)
    {
        registeredScores.Add(id, 0);
    }
}
