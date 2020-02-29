using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchCounter : MonoBehaviour
{

    public bool waiting = true;
    public Text textBody;
    public Text counter;
    public Button button;
    Send_er send_er;

    float timer = 5;

    // Start is called before the first frame update
    void Start()
    {

        send_er = GameObject.FindGameObjectWithTag("Send_er").GetComponent<Send_er>();


    }

    // Update is called once per frame
    void Update()
    {

        if (waiting)
        {

            if (send_er.numPlayers <= 2)
            {

                textBody.text = "Press any button to join.\nAt least 2 players to start.";
                counter.text = (send_er.numPlayers - 1).ToString() + " players";

            }

            else
            {

                textBody.text = "Press any button to join.\nAt least 2 players to start.\nGood to go!";
                counter.text = (send_er.numPlayers - 1).ToString() + " players";
                waiting = false;


            }

        }


        else {

            timer -= Time.deltaTime;

            textBody.text = "\n\nStarting in...";
            counter.text = Mathf.Round (timer).ToString ();

            if (timer < 0)
            {

                Destroy(gameObject);

            }

        }


    }


    public void Begin ()
    {

        waiting = false;

    }

}
