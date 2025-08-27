using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private PlayerActions playerActions;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    [SerializeField]
    private float jumpForce;
    private float jump;
    private bool grounded;
    private float gravityScale = 5f;
    private float fallingGravityScale = 15f;

    private void Awake()
    {
        playerActions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();

        if(rb != null)
        {
            Debug.Log("Rigidbody2D not found");
        }
    }

    private void OnEnable()
    {
        playerActions.PlayerActionMap.Enable();
    }

    private void OnDisable()
    {
        playerActions.PlayerActionMap.Disable();
    }

    private void FixedUpdate()
    {
        moveInput = playerActions.PlayerActionMap.Movement.ReadValue<Vector2>();
        rb.linearVelocityX = moveInput.x * speed;

        jump = playerActions.PlayerActionMap.Jump.ReadValue<float>();

        if(jump == 1 && grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            grounded = false;
        }

        if (rb.linearVelocityY >= 0)
        {
            rb.gravityScale = gravityScale;
        }

        else if (rb.linearVelocityY < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }
}
