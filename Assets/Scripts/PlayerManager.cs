using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    Vector2 move;
    public float speed = 9;

    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private GameObject spawnPoint;

    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private PlayerHealth playerHealth;

    [SerializeField] //[SerializeField] Allows the private field to show up in Unity's inspector. Way better than just making it public
    private LayerMask ground;

    private bool m_Started;

    #region Audio
    [SerializeField]
    private AudioClip jumpSound;
    private AudioSource aud;
    #endregion

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    #region Jumping
    bool jump;
    public float jumpForce = 5;
    bool onGround;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        m_Started = true;

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");

        if (IsWallRight())
        {
            if (move.x > 0)
            {
                move.x = 0;
            }
        }

        if (IsWallLeft())
        {
            if (move.x < 0)
            {
                move.x = 0;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            jump = true;
        }

        if(move.x > 0)
        {
            //Flip character so they move right
            sr.flipX = false;
        }
        else if(move.x < 0)
        {
            //Flip character so they move left
            sr.flipX = true;
        }
        anim.SetFloat("speed", rb.velocity.magnitude);

        if(playerHealth.GetHealth() == 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        //rb.AddForce(move * speed);
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);

        if (jump == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            aud.PlayOneShot(jumpSound);
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Hazzard")
        {
            playerHealth.TakeDamage();
            print($"Hazzard Hit, current health {playerHealth.GetHealth()}");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Kill Plane")
        {
            playerHealth.TakeDamage(playerHealth.GetHealth());
        }
    }

    /**
     * 
     */
    private void Die()
    {
        print("Player Died. Resetting");
        /**
         * TODO:
         * 1. Set health back to max health
         * 2. Respawn Player
         * 3. Invincibility Period
         */

        //2. Respawn Player
        transform.position = spawnPoint.transform.position;
        playerHealth.ResetHealth();
    }

    private bool IsGround()
    {
        Vector2 point = new Vector2(transform.position.x, transform.position.y - .5f);
        Vector2 size = new Vector2(.3f, .05f);
        return Physics2D.OverlapBox(point, size, -90, ground);
    }

    private bool IsWallRight()
    {
        Vector2 point = new Vector2(transform.position.x + .2f, transform.position.y);
        Vector2 size = new Vector2(.3f, .5f);
        return Physics2D.OverlapBox(point, size, 0, ground);
    }

    private bool IsWallLeft()
    {
        Vector2 point = new Vector2(transform.position.x - .2f, transform.position.y);
        Vector2 size = new Vector2(.3f, .5f);
        return Physics2D.OverlapBox(point, size, 0, ground);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(transform.position.x, transform.position.y - .5f, 0));
    }

}
