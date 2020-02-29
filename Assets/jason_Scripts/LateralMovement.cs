using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateralMovement : MonoBehaviour
{
    Rigidbody rb;
    VerticalJump vj;
    Animator anim;


    public LayerMask playerLayer;

    [SerializeField]
    private GameObject worldCylinder;

    [SerializeField]
    private SphereCollider col;

    [SerializeField]
    private float maxSpeed = 0;
    [SerializeField]
    private float m_AccelScale = 1;
    [SerializeField]
    private float m_DeccelScale = 0.1f;


    private float lateralInput;

    [SerializeField]
    private float lateralVel; //previously had getter setter
        
    [SerializeField]
    private float radius = 15;

    private float mAccel = 0;

    [SerializeField]
    private float dashBonus = 0;

    [SerializeField]
    private float gravPause = 0;

    [SerializeField]
    private Transform cameraTarget;

    [SerializeField]
    private float coolDownSetter = 0;

    private float coolDown = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = worldCylinder.transform.position + new Vector3(0, 0.5f, radius);
        col = GetComponent<SphereCollider>();
        vj = GetComponent<VerticalJump>();
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        coolDown = 0;
    }

    public void UpdateInput(float lateralInput) {

        if (Mathf.Abs(lateralVel) < 2) lateralVel += lateralInput;

    }

    public void SlapInteraction(Vector3 raydirection)
    {
        RaycastHit hit;

        bool isHit = Physics.Raycast(new Ray(transform.position, raydirection), out hit, 0.8f, playerLayer);

        if (isHit)
        {
           LateralMovement lm = hit.transform.GetComponent<LateralMovement>();

            lm.lateralVel = lateralVel + dashBonus;

        }


    }


    // Update is called once per frame
    void Update()
    {

        if (coolDown > 0) {
            coolDown = coolDown - 1;
        } else if (coolDown < 0) {
            coolDown = 0;
        }


        lateralVel = lateralVel * (1 - m_DeccelScale);

        

        // Move character counter-clockwise along tower.
        if (lateralVel < 0 && !isLeftCollision()) {

            this.transform.RotateAround(worldCylinder.transform.position, Vector3.up, maxSpeed * lateralVel * Time.deltaTime);


        }

        // Move character clockwise along tower.
        if (lateralVel > 0 && !isRightCollision()) {

            this.transform.RotateAround(worldCylinder.transform.position, Vector3.up, maxSpeed * lateralVel * Time.deltaTime);


        }

        anim.SetFloat("Lat", lateralVel);
        anim.SetFloat("Speed", Mathf.Abs(lateralVel));
        
    }

    public void dashRight() {
        Vector3 currentVel = rb.velocity;

        this.rb.velocity = this.rb.velocity - new Vector3(0, currentVel.y/3, 0);
       
        this.lateralVel = -dashBonus;

        if (gravPause > 0)
        {
            SlapInteraction(transform.right * -1);
        }
    }

    public void dashLeft() {
        Vector3 currentVel = this.rb.velocity;

        this.rb.velocity = this.rb.velocity - new Vector3(0, currentVel.y/3, 0);
        
        this.lateralVel = dashBonus;

        if (gravPause > 0)
        {
            SlapInteraction(transform.right);
        }
    }

    IEnumerator weightless(Vector3 initialVelocity) {
        this.rb.useGravity = false;

        yield return new WaitForSeconds(gravPause);

        this.rb.useGravity = true;
        this.rb.velocity = new Vector3(initialVelocity.x, 0, initialVelocity.z);
    }

    private bool isRightCollision() {
        return Physics.Raycast(transform.position, transform.right, col.bounds.extents.x * 2, vj.groundMask);

    }

    private bool isLeftCollision() {
        return Physics.Raycast(transform.position, (-1) * transform.right, col.bounds.extents.x * 2, vj.groundMask);
    }

    public Transform GetCameraTarget() {
        return cameraTarget;
    }
}
