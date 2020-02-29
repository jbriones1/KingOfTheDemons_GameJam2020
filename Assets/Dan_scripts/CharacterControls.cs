using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{

    DemonInput controls;

    InputDevice device;

    LateralMovement lm;
    VerticalJump vj;

    public Vector2 movement;


    private void Awake()
    {
        lm = GetComponent<LateralMovement>();
        vj = GetComponent<VerticalJump>();

        controls = GetComponent<DemonInput> ();

        uint userId = GetComponent<PlayerInput>().user.id;
       
        


    }
    
    
    void OnDash()
    {

        if (movement.x < 0)
            lm.dashLeft();

        if (movement.x > 0)
            lm.dashRight();

    }

    //Input Actions
    void Update()
    {

        lm.UpdateInput(-movement.x);


    }

    private void OnDisable()
    {

        this.enabled = true;

    }

    void OnJump() {

        
        vj.Jump();

    }

   

    void OnRecolor() {

        RandomColor rc = GetComponentInChildren<RandomColor>();
        rc.UpdateColor();

    }

    void OnMove(InputValue value) {

        movement = value.Get<Vector2>();

    }


}
    
