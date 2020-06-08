using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
public enum MCState {idle, run, dead, attack}

    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private GameObject hitRange;

    public MCState currentMCState;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxcollider2d;


    public float forceX = 50f;
    private bool FaceRight;

    public bool dead;

    private bool jump;
    public float jumpForce = 3f;

    PlayerStats playerstats;

    public Transform spawnPoint;
    void Awake()
    {
        dead = false;
        currentMCState = MCState.idle;
        animator = GetComponent<Animator>();
        animator.SetInteger("MCState", (int)MCState.idle);
        gameObject.transform.localPosition = spawnPoint.localPosition;
        rb = GetComponent<Rigidbody2D>();
        boxcollider2d = GetComponent<BoxCollider2D>();
        FaceRight = true;
        playerstats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        Attack();
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerstats.Health = 0;
        }
    }

    public void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        bool isWalking = Mathf.Abs(inputX) > 0;
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

        if(isGrounded() && jump)
        {
            //no animation yet.   // animator.SetInteger("MCState", (int)MCState.jump);
            rb.velocity = Vector2.up * jumpForce;
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
        playerstats.Health = 100;
        dead = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycasthit2d = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size, 0f, Vector2.down, .1f, groundLayerMask);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }

    private void Dead()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            dead = true;
        }
    }

    IEnumerator AttackPattern()
    {
        animator.Play("MC_Attack");
        hitRange.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        hitRange.SetActive(false);
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(AttackPattern());

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
