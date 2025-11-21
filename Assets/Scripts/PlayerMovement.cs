using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 12f;
    public float gravity = -9.81f;

    [Header("References")]
    public Animator animator;          
    public Transform playerCamera;    

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isSprinting;

    private Vector2 moveInput;

    void Awake()
    {
        controller = GetComponent<CharacterController>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnSprint(InputValue value)
    {
        isSprinting = value.isPressed;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        Vector3 forward = playerCamera ? Vector3.ProjectOnPlane(playerCamera.forward, Vector3.up).normalized : transform.forward;
        Vector3 right = playerCamera ? Vector3.ProjectOnPlane(playerCamera.right, Vector3.up).normalized : transform.right;

        Vector3 move = forward * moveInput.y + right * moveInput.x;
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        bool isMoving = move.magnitude > 0.1f;
        if (animator != null)
        {
            animator.SetBool("isMoving", isMoving);
            animator.SetBool("isSprinting", isSprinting && isMoving);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            FindFirstObjectByType<JumpscareController>()?.PlayJumpscare();
        }
    }
}
