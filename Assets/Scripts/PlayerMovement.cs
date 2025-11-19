using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
	public float sprintSpeed = 10f;

    public float gravity = -9.81f;
	public Vector3 spawnPoint = new Vector3(31.3f, 2.56f, -0.31f);

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

	private bool isSprinting;

    private Vector2 moveInput;

	void Awake()
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
		isSprinting = value.isPressed;
	}

    void Update()
    {
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

	private void OnCollisionEnter(Collision collision)
	{
    	if (collision.gameObject.CompareTag("Enemy"))
    	{
        	FindFirstObjectByType<JumpscareController>().PlayJumpscare();
    	}
	}


}