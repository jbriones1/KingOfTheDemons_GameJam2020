using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchState : MonoBehaviour
{
    // Is the match started and live?
    [Header("Game State")]
    public bool ShouldStartCDImmediately;

    private bool IsMatchLive;
    // Are we counting down to match start?
    private bool IsCountingDown;

    [Header("Asset References")]
    public GameObject PlayerPrefab;
    public GameObject CameraPrefab;

    public GameObject[] spawnPoints;

    [SerializeField]
    private float PreMatchCountdownTime;

    private float runningCountdownTime;
    private int numPlayers = 3;

    private MatchState matchState;
    private Scorekeeper scoreKeeper;

    public Dictionary<int, GameObject> RegisteredPlayers;

    private void Awake()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("Scorekeeper").GetComponent<Scorekeeper>();
    }

    public void Start()
    {
        RegisteredPlayers = new Dictionary<int, GameObject>();
        runningCountdownTime = PreMatchCountdownTime;


        matchState = GameObject.FindGameObjectWithTag("MatchState").GetComponent<MatchState>();
        DontDestroyOnLoad(matchState.gameObject);
    }

    public void StartMatchWithNumPlayers(int numPlayers)
    {
        this.numPlayers = numPlayers;
        InitPlayers();
        StartCoroutine(StartMatch());
    }

    // Initializes all players, registers them with the score system.
    public void InitPlayers()
    {
        for (int i = 0; i < numPlayers; i++)
        {
            Debug.Log("I should be here");
            // Create a player object
            GameObject NewPlayer = Instantiate(PlayerPrefab, new Vector3(0,0,0), Quaternion.identity);
            NewPlayer.GetComponent<PlayerPickupModule>().SetId(i + 1);
            //var camTarget = NewPlayer.GetComponent<LateralMovement>().GetCameraTarget();
            
            //var Camera = NewPlayer.GetComponentInChildren<Camera>();

            //RegisteredPlayers.Add(i + 1, NewPlayer);
            //scoreKeeper.RegisterPlayer(i + 1);
        }


    }

    // Starts a parallel coroutine for starting the match.
    private IEnumerator StartMatch()
    {
        IsCountingDown = true;
        yield return new WaitForSeconds(PreMatchCountdownTime);
        IsMatchLive = true;

        yield return null;
    }

    public GameObject GetPlayerWithID(int playerID)
    {
        return RegisteredPlayers[playerID];
    }
}
