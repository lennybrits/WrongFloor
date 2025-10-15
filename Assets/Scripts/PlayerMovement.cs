using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
	public float sprintSpeed = 10f;

    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

	private bool isSprinting;

    private Vector2 moveInput;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // This will be called automatically by Player Input when Move is performed
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

	void OnSprint(InputValue value)
	{
		bool sprintPressed = value.isPressed;
		isSprinting = sprintPressed;
	}

    void Update()
    {
        // Ground check
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

		float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // Movement
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(move * currentSpeed * Time.deltaTime);

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    // Called automatically when Jump is pressed
    void OnJump(InputValue value)
    {
        if (isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}