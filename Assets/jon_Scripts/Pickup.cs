using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] public int PickupVal { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        PickupVal = 5;   
    }

    public void pickedUp()
    {
        Destroy(this.gameObject);
    }

}
