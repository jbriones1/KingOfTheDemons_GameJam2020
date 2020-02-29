using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class UI_ReadyToggle : MonoBehaviour
{
    [SerializeField]
    private Image Checkmark;

    [SerializeField]
    private TextMeshProUGUI ReadyText;

    [SerializeField]
    private TextMeshProUGUI KeyPrompt;

    [SerializeField]
    private bool playerReady;
    // Start is called before the first frame update
    void Start()
    {
        playerReady = false;
        ReadyText.text = "NOT READY";
        Checkmark.enabled = false;
        KeyPrompt.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePlayerReady()
    {
        playerReady = !playerReady;
        if (playerReady)
        {
            ReadyText.text = "READY!";
            Checkmark.enabled = true;
            KeyPrompt.enabled = false;
        } else
        {
            ReadyText.text = "NOT READY";
            Checkmark.enabled = false;
            KeyPrompt.enabled = true;
        }
    }
}
