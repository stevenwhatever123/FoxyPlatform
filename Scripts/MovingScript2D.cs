using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class MovingScript2D : MonoBehaviour
{
    // Component Reference
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameController gameController;

    // Moving speed of the character
    public float speed;
    // Jump speed of the character
    public float jumpSpeed;
    // Boolean to check if the player is jumping
    private bool jumping;
    // Boolean to save if the keyboard/screen input is jump
    private bool jump;
    // Boolean to hold if it is the player's first fall
    // It is used to prevent the player to gain any score when the game first started
    private bool firstFall = true;
    // Multiplier for calculating falling calculations
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.isGameOver()){
            KeyBoardMovement();
            checkJumpInput();
        }
        Falling();
    }

    void FixedUpdate(){
        Jump();
    }

    void KeyBoardMovement(){

        // Updating player's velocity on the x axis
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal");

        rb.velocity += (Vector2.right * moveX) * speed * Time.deltaTime;
        if(moveX == 0){
            // Running animation disable
            // Leading to Idle animation
            animator.SetBool("running", false);
        } else if(moveX < 0){
            // Flip the character so the character can face the left
            spriteRenderer.flipX = true;
            // Running animation enable
            animator.SetBool("running", true);
        } else if(moveX > 0){
            // Flip the character so the character can face the right
            spriteRenderer.flipX = false;
            // Running animation enable
            animator.SetBool("running", true);
        }

    }

    // This methods used to check if the player jumps in Update() function and
    // passed to FixedUpdate() for physical calculations
    void checkJumpInput(){
        if(CrossPlatformInputManager.GetButtonDown("Jump")){
            if(!jumping){
                jumping = true;
                jump = true;
                animator.SetBool("jumping", jumping);
            }
        }
    }

    // Method to jump
    void Jump(){ 
        if(jump){
            rb.AddForce(Vector2.up * jumpSpeed * Time.deltaTime, ForceMode2D.Impulse);
            jump = false;
        }
    }

    // Falling extra calculation
    void Falling(){
        if(rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier -1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier -1) * Time.deltaTime;
        }
    }

    // Check collision with the Platfrom
    void OnCollisionEnter2D(Collision2D collision){
        jumping = false;
        animator.SetBool("jumping", jumping);
        if(!gameController.isGameOver()){
            if(collision.gameObject.tag == "Platform"){
                updateScore(collision);
            }
        }
    }

    // Update the score whenever the player step on the platform
    void updateScore(Collision2D collision){
        bool steppedBefore = false;
        ArrayList temp = gameController.getSteppedPlatform();

        // Check if the player stepped on the platform before
        foreach(GameObject platform in gameController.getSteppedPlatform()){
            if(collision.gameObject.GetInstanceID() == platform.GetInstanceID()){
                steppedBefore = true;
            }
        }

        // If not, we add the score and extra time.
        // Then add it to our stepped platform array list
        if(!steppedBefore && !firstFall){
            gameController.addScore(10);
            gameController.addTime();
            gameController.steppedPlatform.Add(collision.gameObject);
        }

        // If it is the character's first fall, we set first fall to false
        if(firstFall == true){
            firstFall = false;
        }
    }
}
