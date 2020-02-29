using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupModule : MonoBehaviour
{
    // Incrementer variable that increments whenever something is picked up
    [SerializeField] 
    private int m_Counter;

    [SerializeField]
    private int id;

    // Start is called before the first frame update
    void Start()
    {
        m_Counter = 0;
    }


    // Increments the m_incrementer variable
    // Calls the event controllers GameScoreChange method
    // n is the amount to increment by
    public void Increment(int n)
    {
        m_Counter += n;
        GameEvents.eventController.GameScoreChange(id, n);
    }

    // Collision with the player
    private void OnTriggerEnter(Collider c)
    {
        // TODO: Add tag "Pickup" to the Project Settings
        if (c.gameObject.tag == "Pickup")
        {
            Pickup cPickup = c.gameObject.GetComponent<Pickup>(); // Finds the component Pickup on the player
            Increment(cPickup.PickupVal);                         // Changes the counter by the value of the pickup
            cPickup.pickedUp();                                   // Calls the pickup value's method
        }
    }
    public int GetId()
    {
        return id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
}
