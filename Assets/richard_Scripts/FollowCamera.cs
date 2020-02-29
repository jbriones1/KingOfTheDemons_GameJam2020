using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public int playerID = 2;

    [SerializeField]
    private float mFollowSpeed;

    [SerializeField]
    private float mRotationSpeed;

    [SerializeField]
    private GameObject mCameraTarget;

    [SerializeField]
    private GameObject mPlayerTarget;

    [SerializeField]
    private bool mRotationLerpLocked = true;

    [SerializeField]
    private int mNumPlayer;

    private Camera mCamera;

    private void Awake()
    {
        mCamera = GetComponentInChildren<Camera>();
    }

    public void InitFollowCamera(GameObject camTarget, GameObject playerTarget, float camOffset)
    {
        this.mCameraTarget = camTarget;
        this.mPlayerTarget = playerTarget;
        ViewportChange();
    }

    // Start is called before the first frame update
    void Start()
    {
        ViewportChange();
        //mNumPlayer = GameObject.FindGameObjectWithTag("MatchState").GetComponent<MatchState>().RegisteredPlayers.Count;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mCameraTarget.transform.position;

        if (mRotationLerpLocked)
        {
            transform.rotation = mCameraTarget.transform.rotation;
        }
        else
        {
            Vector3 targetDir = mPlayerTarget.transform.position - transform.position;
            Quaternion interRotation = Quaternion.LookRotation(targetDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, interRotation, mRotationSpeed * Time.deltaTime);
        }
        
    }

    public void ViewportChange()
    {
        switch(mNumPlayer)
        {
            case 2:
                if (playerID == 1)
                {
                    mCamera.rect = new Rect(0, 0, 0.5f, 1f);
                }
                else
                {
                    mCamera.rect = new Rect(0.5f, 0, 0.5f, 1f);
                }
                break;
            case 3:
                if (playerID == 1)
                    mCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    
                else if (mPlayerTarget.GetComponent<PlayerPickupModule>().GetId() == 2)
                    mCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                else
                    mCamera.rect = new Rect(0, 0, 1, 0.5f);
                break;
            case 4:
                if (mPlayerTarget.GetComponent<PlayerPickupModule>().GetId() == 1)
                    mCamera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                else if (mPlayerTarget.GetComponent<PlayerPickupModule>().GetId() == 2)
                    mCamera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                else if (mPlayerTarget.GetComponent<PlayerPickupModule>().GetId() == 3)
                    mCamera.rect = new Rect(0, 0, 0.5f, 0.5f);
                else
                    mCamera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                break;
        }
    }

    public void SetPlayerID(int id)
    {
        playerID = id;
    }

    public int GetPlayerID()
    {
        return playerID;
    }
}
