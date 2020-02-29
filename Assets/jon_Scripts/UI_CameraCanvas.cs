using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_CameraCanvas : MonoBehaviour
{
    [Header("Cached References")]
    [SerializeField]
    private TextMeshProUGUI tmpgui;
    private FollowCamera fc;
    [SerializeField]
    private Scorekeeper sk;

    [Header("Visible variables")]
    [SerializeField]
    private int playerId;

    private void Awake()
    {
        sk = FindObjectOfType<Scorekeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.eventController.onGameScoreChange += OnGameScoreChange;
        fc = GetComponent<FollowCamera>();

        playerId = fc.GetPlayerID();

        tmpgui.SetText("Souls: " + sk.GetScoreById(1));
    }

    // Update is called once per frame
    void OnGameScoreChange(int id, int value)
    {
        if (playerId == id)
        {
            tmpgui.SetText("Souls: " + sk.GetScoreById(id));
        }
    }
}
