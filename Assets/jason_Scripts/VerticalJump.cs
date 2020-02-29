using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EZCameraShake;

public class VerticalJump : MonoBehaviour
{

    Animator anim;

    private PlayerPickupModule ppm;

    [SerializeField]
    private Transform groundPos;

    [SerializeField]
    public LayerMask groundMask;

    [SerializeField]
    private float jumpForce = 0;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private SphereCollider col;


    [SerializeField]
    private float hoverStrength = 20;

    private bool hover;

    private bool inAir = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        anim = GetComponentInChildren<Animator>();
        ppm = GetComponent<PlayerPickupModule>();

    }

    // Update is called once per frame
    void Update()
    {


        if (hover)
            rb.AddForce(Vector3.up * hoverStrength * Time.deltaTime);


        anim.SetBool("Ground", isGrounded());
        anim.SetBool("Hover", hover);
        anim.SetFloat("Vert", rb.velocity.y);
    }

    public void Jump() {

        Vector3 vel = rb.velocity;
        vel.y = jumpForce;

        if (isGrounded()) {

            rb.velocity = vel;
            anim.SetTrigger("Jump");

        }

    }

    private void FixedUpdate()
    {

        Vector3 vel = rb.velocity;
        vel.y = Mathf.Clamp(vel.y, -2.5f, 10);
        rb.velocity = vel;


    }

    public bool isGrounded() {
        return Physics.CheckSphere(groundPos.position, 0.19f, groundMask);
    }
    
}
