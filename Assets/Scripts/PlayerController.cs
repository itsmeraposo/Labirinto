using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float mouseSensitivity = 0.08f;

    private Rigidbody rb;
    private float yaw;
    private Vector3 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void Start()
    {
        yaw = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovementInput();
    }

    void FixedUpdate()
    {
        RotatePlayer();
        ApplyMovement();
    }

    void HandleMouseLook()
    {
        if (Mouse.current == null) return;
        float mouseX = Mouse.current.delta.x.ReadValue();
        yaw += mouseX * mouseSensitivity;
    }

    void RotatePlayer()
    {
        rb.MoveRotation(Quaternion.Euler(0f, yaw, 0f));
    }

    void HandleMovementInput()
    {
        moveInput = Vector3.zero;
        Keyboard kb = Keyboard.current;
        if (kb == null) return;

        if (kb.wKey.isPressed) moveInput.z += 1f;
        if (kb.sKey.isPressed) moveInput.z -= 1f;
        if (kb.aKey.isPressed) moveInput.x -= 1f;
        if (kb.dKey.isPressed) moveInput.x += 1f;
        moveInput.Normalize();
    }

    void ApplyMovement()
    {
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * moveInput.z) + (right * moveInput.x);
        direction.Normalize();

        Vector3 velocity = direction * speed;
        velocity.y = rb.linearVelocity.y;
        rb.linearVelocity = velocity;
    }
}