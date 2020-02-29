using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPickupSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnerQuadrant;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform quadrant in transform)
        {
            spawnerQuadrant.Add(quadrant.gameObject);
        }
    }
}
