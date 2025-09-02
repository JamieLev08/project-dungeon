using Unity.Cinemachine;
using UnityEditor.Animations;
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
    private float fallingGravityScale = 5f;

    private Animator animator;

    private void Awake()
    {
        playerActions = new PlayerActions();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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

        if (moveInput.x < 0)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, 180, 0, 0));
        }
        else if(moveInput.x > 0)
        {
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
        }

        animator.SetFloat("VelocityX", rb.linearVelocityX);
        animator.SetFloat("VelocityY", rb.linearVelocityY);
        animator.SetBool("Grounded", grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            grounded = true;
        }
    }
}
