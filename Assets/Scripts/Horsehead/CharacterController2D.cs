using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 100f;                          // Amount of force added when the player jumps.
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character

    private bool m_Grounded;            // Whether or not the player is grounded.
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 m_Velocity = Vector3.zero;
    private Animator animator;

    public GameObject bulletPrefab;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = m_Rigidbody2D.velocity.y == 0;
        if (wasGrounded != m_Grounded && m_Grounded)
        {
            animator.SetBool("Grounded", true);
        }
    }


    public void Move(float move, bool jump)
    {

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            //if (move > 0 && !m_FacingRight)
            //{
            //    // ... flip the player.
            //    Flip();
            //}
            //// Otherwise if the input is moving the player left and the player is facing right...
            //else if (move < 0 && m_FacingRight)
            //{
            //    // ... flip the player.
            //    Flip();
            //}
            animator.SetInteger("Movement direction", (int)move);
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(transform.up * m_JumpForce);
            animator.SetBool("Grounded", false);
        }


    }

        void OnCollisionEnter2D(Collision2D other)
        {
        Debug.Log("Touched!");

        if (other.gameObject.CompareTag("Exit"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(sceneBuildIndex: scene.buildIndex + 1);
            Debug.Log("Active Scene is '" + scene.name + "'.");
        } else if (other.gameObject.CompareTag("Enemy"))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(sceneBuildIndex: scene.buildIndex);
        }


        }
    //private void Flip()
    //{
    //    // Switch the way the player is labelled as facing.
    //    m_FacingRight = !m_FacingRight;

    //    // Multiply the player's x local scale by -1.
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);
    }
}