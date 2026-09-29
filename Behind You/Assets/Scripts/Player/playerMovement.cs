using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float hor;
    private float vert;
    private float movementSpeed = 10f;
    private Vector3 moveDir;
    public Transform cameraTransform;
    private float sensitivity = 100f;
    private float xRotation = 0f;

    private bool isGrounded;
    private float jumpForce;
    private Rigidbody rb;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Movement();
        CameraMovement();
    }
    private void FixedUpdate() { if(Input.GetKeyDown(KeyCode.Space) && isGrounded) { Jump(); } }

    private void Movement()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        moveDir = new Vector3(hor, 0, vert);
        transform.Translate(moveDir * movementSpeed * Time.deltaTime);
    }

    private void CameraMovement()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -86f, 86f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
    private void Jump() 
    { 
        isGrounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
