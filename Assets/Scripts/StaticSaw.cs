using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSaw : MonoBehaviour{
    private Animator animator;
    public GameObject LevelController;

    void Start(){
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }
    void Update(){
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !LevelController.GetComponent<Level_01_Controller>().isEnd){
            animator.speed = 1f;
        }
        else{
            animator.speed = 0f;
        }
    }
}
