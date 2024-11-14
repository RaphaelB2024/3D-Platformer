using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //camera vaariables
    public float sensitivity = 100f;
    float xRotation = 0f;
    public Transform playerCamera;
    
    public float Speed = 3f;
    public float jumpForce = 5f;
    Rigidbody rb;

    public Transform groundCheck;
    public LayerMask ground;

    public AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Move in direction facing
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.velocity = new Vector3(moveDirection.x * Speed, rb.velocity.y, moveDirection.z * Speed);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        
        //Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); //Clamp Vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Rotate camera
        transform.Rotate(Vector3.up * mouseX); //Rotate player
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
