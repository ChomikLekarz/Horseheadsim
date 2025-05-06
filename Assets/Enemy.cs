using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    public float directionChangeInterval = 2f;
    public float jumpChance = 0.3f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool movingRight = true;
    private float nextDirectionChangeTime = 0f;

    private bool m_Grounded;            



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseNewDirection();
    }

    void Update()
    {
        
        spriteRenderer.flipX = !movingRight;

        
        if (Time.time >= nextDirectionChangeTime)
        {
            ChooseNewDirection();
        }

    }

    void FixedUpdate()
    {
      
        float moveDirection = movingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        m_Grounded = rb.velocity.y >= -1 && rb.velocity.y <= 1;

    }

    void ChooseNewDirection()
    {
        nextDirectionChangeTime = Time.time + directionChangeInterval;

      
        movingRight = Random.value > 0.5f;

       
        if (Random.value < jumpChance && m_Grounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
