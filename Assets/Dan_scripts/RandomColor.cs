using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    [SerializeField]
    private Color[] colors = new Color[5];


    private void Awake()
    {

        Send_er send_er = GameObject.FindGameObjectWithTag("Send_er").GetComponent<Send_er>();
        UpdateColor(send_er.numPlayers-1);
        
    }

    
    public void UpdateColor (int id = -1)
    {

        if (id == -1) id = Random.Range(0, colors.Length);

        Color color = colors[id];

        foreach (Renderer render in GetComponentsInChildren<Renderer>())
        {

            render.material.SetColor("Char_Color", color);

        }

        Light light = GetComponentInChildren<Light>();
        if (light != null) {

            light.color = color;

        }

        
    }
    
}
