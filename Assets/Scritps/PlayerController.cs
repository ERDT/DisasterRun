using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public AudioSource jumpSound;
    public AudioSource deathSound;
    private float moveSpeedStore;
    private float speedMilestoneCountStore;
    public float speedIncreaseMilestoneStore;
    public float Startspeed = 0;
    private float moveSpeed;
    public float jumpForce;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public float jumpBoost;
    public bool fly=false;
    public float xJump = 0;
    public float jumped;
    private float forceJump;
    public bool stomp;
    public float stompSpeed;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool canDoubleJump;
    private AudioSource mainMusic;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    public GameManager theGameManager;
    private bool stoppedJumping;
    //private Collider2D myCollider;

    private Animator myAnimator;

    // Use this for initialization
    void Start () {
        mainMusic = GameObject.Find("Music").GetComponent<AudioSource>();
        stoppedJumping = true;
        jumpTimeCounter = jumpTime;
        jumped = xJump;
        moveSpeed = Startspeed;
        forceJump = jumpForce-xJump;
        myRigidbody = GetComponent<Rigidbody2D>();

        //myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x > speedMilestoneCount) {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
            jumped = jumped + jumpBoost;
        }

        if (moveSpeed > 50) {
            moveSpeed = 49;
        }
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            
            if (canDoubleJump || grounded)
            {
                jumpSound.Play();
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                stoppedJumping = false;
                xJump--;
               jumpTimeCounter = jumpTime;
               canDoubleJump = (xJump >= 1);
            }
            else {
              myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -stompSpeed);
                stomp = true;
            }
        }
           if((Input.GetKey  (KeyCode.Space) || Input.GetMouseButton(0) ) && !stoppedJumping)
            {
                if (jumpTimeCounter > 0)
                {       
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;

                }
            }
            
        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))) {
            stoppedJumping = true;
            jumpTimeCounter = 0;
        }
        if (grounded)
        {
            stomp = false;
            xJump = jumped;
            canDoubleJump = (xJump >= 1);
            jumpTimeCounter = jumpTime;      

        }





       
        
        
        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);

        myAnimator.SetBool("Grounded", grounded);
        myAnimator.SetBool("Stomp", stomp);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            mainMusic.Stop();
            deathSound.Play();
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }

    
    }
}
