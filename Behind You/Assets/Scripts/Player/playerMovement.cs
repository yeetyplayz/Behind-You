using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Movement Variables
    private float movementSpeed = 400f;
    private float maxMovement = 9f;
    private float hor;
    private float vert;

    // Jump Variables
    private Rigidbody rb;
    private bool isGrounded = true;
    private float movementBoost = 15f;
    private float jumpForce = 50f;

    private void Start() { rb = GetComponent<Rigidbody>(); }

    private void Update()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { Jump(); }
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
                horVel.x * 0.7f,
                rb.linearVelocity.y,
                horVel.z * 0.7f
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
            movementSpeed = 400f;
        }
        else return;
    }
    public void GameOver()
    { }
}
