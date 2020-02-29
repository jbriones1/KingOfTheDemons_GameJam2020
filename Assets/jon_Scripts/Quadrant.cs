using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quadrant : MonoBehaviour
{
    [Header("Cached references")]
    [SerializeField] private GameObject[] pickups;
    [SerializeField] private List<GameObject> spawners;

    // Boolean on whether it should be spawning or not
    public bool active{ get; set; }

    // Number of pickups spawning per quadrant
    public int numPickupsSpawning { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        numPickupsSpawning = 12;
        active = true;
        foreach (Transform spawner in transform)
        {
            spawners.Add(spawner.gameObject);
        }
        Spawn();
    }

    // Spawn pickups at a random fixed amount of spawners
    public void Spawn()
    {
        if (active)
        {
            List<int> list = JonUtilities.RandomNoRepeat(0, spawners.Count, numPickupsSpawning);
            for (int i = 0; i < list.Count; i++)
            {
                spawners[i].gameObject.GetComponent<PickupSpawner>().SpawnPickup();
            }
        }
    }
}
