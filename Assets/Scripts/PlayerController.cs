using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float velocity = 5f;
    private float horizontalMovement;

    public float jumpForce = 0.001f;
    private bool wantsToJump;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    private bool inGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (groundCheck != null)
        {
            inGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        }
        else
        {
            inGround = true; 
        }

        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.W);

        if (jumpKeyPressed && inGround)
        { 
            wantsToJump = true;
        }
    }
    
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMovement * velocity, rb.linearVelocity.y);

        if (wantsToJump && inGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            wantsToJump = false;
        }

    }
    
}