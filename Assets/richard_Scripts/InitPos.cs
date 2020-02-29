using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var send_er = GameObject.FindGameObjectWithTag("Send_er").GetComponent<Send_er>();
        var ppm = GetComponent<PlayerPickupModule>();
        ppm.SetId(send_er.numPlayers);

        switch (ppm.GetId())
        {
            case 1:
                transform.position = new Vector3(2.05f, 0.45f, 0);
                transform.eulerAngles = new Vector3(0, 90, 0);
                send_er.numPlayers++;
                break;
            case 2:
                transform.position = new Vector3(-2.05f, 0.45f, 0);
                transform.eulerAngles = new Vector3(0, -90, 0);
                send_er.numPlayers++;
                break;
            case 3:
                transform.position = new Vector3(0, 0.45f, 2.05f);
                transform.eulerAngles = new Vector3(0, 0, 0);
                send_er.numPlayers++;
                break;
            case 4:
                transform.position = new Vector3(0, 0.45f, -2.05f);
                transform.eulerAngles = new Vector3(0, -180, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
