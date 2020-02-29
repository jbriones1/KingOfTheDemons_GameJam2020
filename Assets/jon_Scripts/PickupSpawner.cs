using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [Header("Cached references")]
    [SerializeField] private GameObject[] pickups; 

    public void SpawnPickup()
    {
        Instantiate(pickups[0], transform);
    }
}
