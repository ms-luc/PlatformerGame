using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject camera;

    public float move_speed;
    public float jump_force;

    private Rigidbody rb;

    private string m_MovementAxisName;
    private string m_TurnAxisName;
    private float m_MovementInputValue;
    private float m_HorizontalInputValue;
    private float m_TurnInputValue;

    // true if colliding with any object
    [HideInInspector] public bool onGround = false;

    // saves movement force/direction
    Vector3 inFlightForce = new Vector3(0, 0, 0);

    private void Start()
    { 
        rb = GetComponent<Rigidbody>();

        m_MovementAxisName = "Vertical";
        m_TurnAxisName = "Horizontal";
    }
    

    private void FixedUpdate()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Debug.Log(moveHorizontal);
        //if moveHorizontal, push towards the way the camera is facing
        Vector3 movement = new Vector3(moveHorizontal * move_speed, 0f, moveVertical * move_speed) ;

        rb.AddForce(movement);
        */

        /*
        https://unity3d.com/learn/tutorials/topics/scripting/getbutton-and-getkey
        */

        

        

        m_MovementInputValue = Input.GetAxis(m_MovementAxisName);
        m_HorizontalInputValue = Input.GetAxis(m_TurnAxisName);
        //Vector3 movement = new Vector3(m_MovementInputValue * move_speed, 0f, 0f);
        Vector3 movement = new Vector3(0,0,0);

        //m_TurnInputValue = Input.GetAxis(m_TurnAxisName);

        if (onGround)
        {

            // gets speed from movement input and clamps at max speed, which is determined by the "move_speed" variable
            movement = Vector3.ClampMagnitude(transform.forward* m_MovementInputValue *move_speed + transform.right * m_HorizontalInputValue * move_speed, 10);
            inFlightForce = movement;

            bool down = Input.GetButtonDown("Jump");
            if (down)
                movement.y = jump_force;

            //jumpForce = jump * jump_force; //EDITABLE



        }
        else
        {
            movement = inFlightForce + Vector3.ClampMagnitude(transform.forward * m_MovementInputValue * move_speed + transform.right * m_HorizontalInputValue * move_speed, 10) * 0.5f;
            inFlightForce = inFlightForce * 0.95f;
            
        }

        //Debug.Log("Speed: " + movement);

        rb.AddForce(movement);
        rb.MoveRotation(camera.transform.rotation);

        //Debug.Log("On ground: " + onGround);

    }

}
