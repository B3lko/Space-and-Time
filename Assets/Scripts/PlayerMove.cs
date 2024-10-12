using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{
    [SerializeField] float speed;
    private Animator animator;
    private Rigidbody2D rb;
    // ---- Jump ---- //
    public float jumpForce;         // La fuerza de salto base
    public float maxJumpTime;      // El tiempo máximo que se puede mantener el botón para el salto
    public float minJumpForce;       // La fuerza mínima para el salto
    public float jumpHoldForce;      // Fuerza adicional mientras se mantiene el botón presionado
    private bool isJumping = false;
    private bool isGrounded = false;
    private float jumpTimeCounter;
    private bool isPaused = false;


    void Start(){
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update(){
        /*if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A)){
            isPaused = true;
            rb.simulated = false;
        }
        else{
            isPaused = false;
            rb.simulated = true;*/
            Move();
            Jump();
        //}
    }


    private void Move(){
        if(Input.GetKey(KeyCode.D)){
            if(transform.localScale.x < 0) transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            animator.SetBool("isRunning", true);
        }
        else if(Input.GetKey(KeyCode.A)){
            if(transform.localScale.x > 0) transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            animator.SetBool("isRunning", true);
        }
        else{
            animator.SetBool("isRunning", false);
        }
    }


    private void Jump(){


        if (isGrounded && Input.GetKeyDown(KeyCode.W)){
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (isJumping && Input.GetKey(KeyCode.W)){
            if (jumpTimeCounter > 0){
                rb.simulated = true;

                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpHoldForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else{
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W)){
            isJumping = false;


            if (rb.velocity.y > minJumpForce){
                rb.velocity = new Vector2(rb.velocity.x, minJumpForce);
            }
        }

    }



    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
            Debug.Log("YYYYY");

        }
    }


    private void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }


}