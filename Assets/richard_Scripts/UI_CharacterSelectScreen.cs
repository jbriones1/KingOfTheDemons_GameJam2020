using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.SceneManagement;

public class UI_CharacterSelectScreen : MonoBehaviour
{
    public GameObject StartBanner;

    [SerializeField]
    private int numPlayers = 2;

    private Dictionary<int, bool> playerReadies;

    public UI_ReadyToggle[] readyToggles;

    private bool ReadyToStart = false;

    [SerializeField]
    private TextMeshProUGUI PlayerCountText;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerCountText.text = "2";
        
        InitPlayerReadies();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetPlayerReadyCounts() == numPlayers)
        {
            StartBanner.SetActive(true);
            ReadyToStart = true;

        } else if (StartBanner.activeInHierarchy)
        {
            StartBanner.SetActive(false);
            ReadyToStart = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            playerReadies[0] = !playerReadies[0];
            readyToggles[0].TogglePlayerReady();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerReadies[1] = !playerReadies[1];
            readyToggles[1].TogglePlayerReady();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            playerReadies[2] = !playerReadies[2];
            readyToggles[2].TogglePlayerReady();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerReadies[3] = !playerReadies[3];
            readyToggles[3].TogglePlayerReady();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("dev_daniel");
            GameObject.FindGameObjectWithTag("MatchState").GetComponent<MatchState>().StartMatchWithNumPlayers(numPlayers);
        }


    }

    public IEnumerator StartMatch()
    {
        yield return new WaitForSecondsRealtime(3.0f);
        GameObject.FindGameObjectWithTag("MatchState").GetComponent<MatchState>().StartMatchWithNumPlayers(numPlayers);

        yield return null;
    }

    public void IncreasePlayerCount()
    {
        numPlayers = Mathf.Clamp(numPlayers + 1, 2, 4);
        PlayerCountText.text = numPlayers.ToString();
        animator.SetInteger("CurrentPlayers", numPlayers);
    }

    public void DecreasePlayerCount()
    {
        numPlayers = Mathf.Clamp(numPlayers - 1, 2, 4);
        PlayerCountText.text = numPlayers.ToString();
        animator.SetInteger("CurrentPlayers", numPlayers);
    }

    private void InitPlayerReadies()
    {
        playerReadies = new Dictionary<int, bool>();

        for (int i = 0; i < 4; i++)
        {
            playerReadies.Add(i, false);
        }
    }

    private int GetPlayerReadyCounts()
    {
        int rsf = 0;
        for (int i = 0; i < 4; i++)
        {
            if (playerReadies[i])
                rsf++;
        }

        return rsf;
    }
}
