using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Transform orientation;
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool isReadyToJump = true;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Detection")]
    public float playerHeight;
    public LayerMask groundLayer;
    public bool isGrounded;


    private Rigidbody rb;
    float horizontalInput;
    float verticalInput;


    Vector3 moveDirection;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void InputHandler(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");   
        if(Input.GetKeyDown(jumpKey) && isReadyToJump && isGrounded){
            isReadyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer(){
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if(isGrounded){
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    void Update(){
        CheckGround();
        InputHandler();
        SpeedControl();

        if(isGrounded){
            rb.linearDamping = groundDrag;
        }
        else{
            rb.linearDamping = 0;
        } 
    }

    void FixedUpdate(){
        MovePlayer();
    }

    private void CheckGround(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f, groundLayer);
    }

    private void SpeedControl(){
        Vector3 flatVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if(flatVelocity.magnitude > moveSpeed){
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void Jump(){
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump(){
        isReadyToJump = true;
    }

void OnDrawGizmos()
{
    Gizmos.color = Color.red;

    float radius = 0.3f;
    float distance = playerHeight * 0.5f + 0.2f;

    Vector3 origin = transform.position;
    Vector3 endPoint = origin + Vector3.down * distance;

    // Draw line
    Gizmos.DrawLine(origin, endPoint);

    // Draw starting sphere
    Gizmos.DrawWireSphere(origin, radius);

    // Draw ending sphere
    Gizmos.DrawWireSphere(endPoint, radius);
}

}

