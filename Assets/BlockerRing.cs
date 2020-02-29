using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerRing : MonoBehaviour
{
    public float timeDelay= 10f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
