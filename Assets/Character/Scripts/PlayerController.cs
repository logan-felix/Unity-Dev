using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform view;

    CharacterController controller;
    InputAction moveAction;
    InputAction jumpAction;
    Vector2 movementInput = Vector2.zero;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += OnJump;
        jumpAction.canceled += OnJump;

        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;

        float moveModifier = (controller.isGrounded) ? 1 : 0.1f;

        if (controller.isGrounded)
        {
            velocity.x = movement.x * speed * moveModifier;
            velocity.z = movement.z * speed;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && controller.isGrounded)
        {
            velocity.y = jumpForce;
        }
    }
}
