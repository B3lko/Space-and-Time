using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float speed = 5;
    private Animator animator;
    private bool canMove = true;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void SetMove(bool move){
        canMove = move;
    }

    void FixedUpdate(){
        if (canMove){
            Move();
        }
        //if(!LevelController.GetComponent<Level_01_Controller>().isEnd){
            
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

    void OnCollisionEnter2D(Collision2D other) {
       /* if(other.gameObject.tag == "Trap"){
            LevelController.GetComponent<Level_01_Controller>().SetDeaths();
            if(LevelController.GetComponent<Level_01_Controller>().index == 1){
                transform.position = new Vector3(-8, -13.5f , transform.position.z);
            }
            else if(LevelController.GetComponent<Level_01_Controller>().index == 2){
                transform.position = new Vector3(-3.5f, -0.5f , transform.position.z);
            }
            else if(LevelController.GetComponent<Level_01_Controller>().index == 3){
                transform.position = new Vector3(-3.5f, -0.5f , transform.position.z);
            }
        }
        else if(other.gameObject.tag == "Finish"){
            LevelController.GetComponent<Level_01_Controller>().SetFinish();
            gameObject.SetActive(false);
        }*/
    }


}
