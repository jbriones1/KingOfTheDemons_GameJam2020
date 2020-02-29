using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ProgressMeter : MonoBehaviour
{
    
    [SerializeField]
    private int m_NumPlayers;

    // The Prefab asset that will represent the player on the UI
    [SerializeField]
    private GameObject m_ProgressCaratPrefab;

    private List<GameObject> mCreatedCarats;

    private void Awake()
    {
        mCreatedCarats = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Initializes the progress carats on the
    /// </summary>
    private void ConstructCarats()
    {
        for (int i = 0; i < m_NumPlayers; ++i)
        {
            GameObject newCarat = Instantiate(m_ProgressCaratPrefab, this.transform);
        }
    }
}
