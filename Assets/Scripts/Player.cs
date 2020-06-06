using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
public enum MCState {idle, run, dead}

    public MCState currentMCState;
    private Animator animator;
    private Rigidbody2D rb;

    public float forceX = 50f;
    private bool FaceRight;

    private bool dead;

    private bool jump;
    public float jumpForce = 3f;

    public bool isGrounded;
    public float groundCheckRadius = .02f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform spawnPoint;
    void Start()
    {
        dead = false;
        currentMCState = MCState.idle;
        animator = GetComponent<Animator>();
        animator.SetInteger("MCState", (int)MCState.idle);
        gameObject.transform.localPosition = spawnPoint.localPosition;
        rb = GetComponent<Rigidbody2D>();
        FaceRight = true;
    }

    private void Update()
    {
        Dead();
    }

    public void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        bool isWalking = Mathf.Abs(inputX) > 0;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        bool jumpPressed = Input.GetButtonDown("Jump");

        if (jumpPressed)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }

        if (isWalking)
        {
            if(inputX > 0 && !FaceRight)
            {
                Flip();
            }else if(inputX < 0 && FaceRight)
            {
                Flip();
            }
            animator.SetInteger("MCState", (int)MCState.run);
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.AddForce(new Vector2(inputX * forceX, 0));
        }
        else
        {
            animator.SetInteger("MCState", (int)MCState.idle);
        }

        if(jump && isGrounded)
        {
            //no animation yet.   // animator.SetInteger("MCState", (int)MCState.jump);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0f, jumpForce));
            Debug.Log("jumped");
        }

        if(dead == true)
        {
            Debug.Log("dead");
            StartCoroutine(DeadSeq());
    
        }


    }

    IEnumerator DeadSeq() {

        animator.SetInteger("MCState", (int)MCState.dead);
        yield return new WaitForSecondsRealtime(1f);
        gameObject.transform.position = spawnPoint.position;
        dead = false;
    }

    private void Dead()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dead = true;
        }
    }



    private void Flip()
    {
        FaceRight = !FaceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
