﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision) {
        
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player has entered the win zone.");
            SceneManager.LoadScene("win_screen_jason");

        }

    }
}
