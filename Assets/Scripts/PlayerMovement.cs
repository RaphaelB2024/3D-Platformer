using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed = 3f;
    public float Jump = 5f;
    Rigidbody rb;

    public Transform groundCheck;
    public LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * Speed, rb.velocity.y, verticalInput * 5f);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           rb.velocity = new Vector3(rb.velocity.x,Jump,rb.velocity.z);
        }



    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}