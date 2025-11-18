using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private Transform playerBody; // The player capsule to rotate horizontally
    public float sensX = 1000f;
    public float sensY = 200f;

    private Vector2 lookInput;
    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

		playerBody = GameObject.FindGameObjectWithTag("Player").transform;

    	Vector3 e = transform.localEulerAngles;
    	xRotation = e.x;
    	yRotation = e.y - 90;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRotation += mouseX;
        xRotation -= mouseY;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerBody.rotation = Quaternion.Euler(0, yRotation, 0f);
        
    }

    // Called automatically by Player Input if using Send Messages behavior
    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }
}
