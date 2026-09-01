using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Movement Variables
    private float movementSpeed = 4000f;
    private float maxMovement = 9f;
    private float hor;
    private float vert;

    // Camera Variables
    public float mouseSensitivity = 2f;
    private float cameraRotationX;
    public Transform playerCamera;

    // Jump Variables
    private Rigidbody rb;
    private bool isGrounded = true;
    private float movementBoost = 15f;
    private float jumpForce = 50f;

    private void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }

    private void Update()
    {   
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { Jump(); }
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Rotate(Vector3.up * mouseX);
        cameraRotationX -= mouseY;
        cameraRotationX = Mathf.Clamp(cameraRotationX, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(cameraRotationX, 0f, 0f);
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = transform.right * hor + transform.forward * vert;
        if (moveDir.magnitude > 0.1) { rb.AddForce(moveDir * movementSpeed, ForceMode.Force); }
        else if (isGrounded)
        {
            Vector3 horVel = new Vector3(
                rb.linearVelocity.x,
                0,
                rb.linearVelocity.z
            );

            rb.linearVelocity = new Vector3(
                horVel.x * 0.2f,
                rb.linearVelocity.y,
                horVel.z * 0.2f
            );
        }
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if (isGrounded && horizontalVelocity.magnitude > maxMovement)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxMovement;

            rb.linearVelocity = new Vector3(
                horizontalVelocity.x,
                rb.linearVelocity.y,
                horizontalVelocity.z
            );
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        Vector3 movementDirection = new Vector3(hor, 0, vert);
        if(movementDirection.magnitude > 0.1) { rb.AddForce(movementDirection * movementBoost, ForceMode.Impulse); }
        isGrounded = false;
        movementSpeed = 100f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        { 
            isGrounded = true;
            movementSpeed = 4000f;
        }
        else return;
    }
    public void GameOver()
    { }
}
