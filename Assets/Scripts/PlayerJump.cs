using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour{
    private bool canJump = true;
    private bool isJumping = false;
    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    //public GameObject LevelController;


    private void OnEnable(){
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update(){
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) /*&& !LevelController.GetComponent<Level_01_Controller>().isEnd*/){
            if (Input.GetKeyDown(KeyCode.W) && canJump){
                canJump = false;
            }
        }
    }

    private void FixedUpdate(){
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))/* && !LevelController.GetComponent<Level_01_Controller>().isEnd*/){
            if (!canJump && !isJumping){
                myAnimator.SetBool("isJumping", true);
                Vector2 newVelocity = myRigidbody2D.velocity;
                newVelocity.y +=  4.5f;
                myRigidbody2D.velocity = newVelocity;
                isJumping = true;
            }
            if(myRigidbody2D.velocity.y > 0){
                myAnimator.SetBool("isJumping", false);
                myAnimator.SetBool("isFalling", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject GO = collision.gameObject;
        if(GO.tag == "Floor" || GO.tag == "Trap"){
            if(isJumping){
            }
            myAnimator.SetBool("isFalling",false);
            myAnimator.SetBool("isRunning",true);
            canJump = true;
            isJumping = false;
        }
    }
}