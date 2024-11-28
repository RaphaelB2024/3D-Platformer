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
    
    //Rigidbody and movement
    public float Speed = 3f;
    public float jumpForce = 5f;
   // public float dashX = 4f;
    public float dashY = 2f;
    Rigidbody rb;

    //Ground stuff
    public Transform groundCheck;
    public LayerMask ground;

    //Audio
    public AudioSource jumpSound;

    //upgrade variables
    bool DashUpg = false;
    int MaxDash = 1;
    int Dashes = 0;

    Animator anim;

    public GameObject UpgradeCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get movement inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Move in direction facing
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        rb.velocity = new Vector3(moveDirection.x * Speed, rb.velocity.y, moveDirection.z * Speed);

  

            if (Input.GetButtonDown("Jump"))
            {
                if (IsGrounded())
                {
                    Jump();
                }
            }

            if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                LowJump();
            }

            if(Input.GetButtonDown("Jump") && !IsGrounded() && DashUpg && Dashes > 0)
            {
                Dash();
                Dashes--;              
            }

            if(IsGrounded())
            {
               Dashes = MaxDash;
               anim.SetBool("Grounded",IsGrounded());
            }
        
        //Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); //Clamp Vertical rotation

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Rotate camera
        transform.Rotate(Vector3.up * mouseX); //Rotate player

        //Animation Variables
        anim.SetFloat("Speed", moveDirection.magnitude);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        anim.SetTrigger("Jumped");
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }

    void LowJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * 0.5f, rb.velocity.z);
    }

    void Dash()
    {
        rb.velocity = new Vector3(10, dashY, rb.velocity.z);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }

    void DeactivateUpgrade()
    {
        UpgradeCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DashUpg"))
        {
           DashUpg = true;
           Destroy(other.gameObject);

           UpgradeCanvas.SetActive(true);
            Invoke(nameof(DeactivateUpgrade), 1.3f);

        }
    }
}
