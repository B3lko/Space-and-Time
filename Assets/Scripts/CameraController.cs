using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour{
    public GameObject player;
    public int indexLevel;
    [SerializeField] float Y;

    void Update(){
        if(indexLevel == 1){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            UpdateLevel_1();
        }
        else if(indexLevel == 2){
            transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
            UpdateLevel_2();
        }
        else if(indexLevel == 3){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            UpdateLevel_3();
        }

    }
    private void UpdateLevel_1(){
        transform.position = new Vector3(player.transform.position.x, Y, transform.position.z);
        /*if(transform.position.x > 0 && player.transform.position.y > -10){
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -1){
            transform.position = new Vector3(-1, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 16){
            transform.position = new Vector3(16, transform.position.y, transform.position.z);
        }

        if(transform.position.y > -12 && player.transform.position.y < -9 && player.transform.position.x > -3f){
            transform.position = new Vector3(transform.position.x, -12, transform.position.z);
        }
        else if(transform.position.y > 3){
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
        }

        if(transform.position.y < -13){
            transform.position = new Vector3(transform.position.x, -13, transform.position.z);
        }*/
    }
    private void UpdateLevel_2(){
        if(transform.position.x < 4){
            transform.position = new Vector3(4, 0, transform.position.z);
        }
        if(transform.position.x > 33){
            transform.position = new Vector3(33, 0, transform.position.z);
        }
    }

    private void UpdateLevel_3(){
        if(transform.position.x < 4){
            transform.position = new Vector3(4, transform.position.y, transform.position.z);
        }
        if(transform.position.x > 25){
            transform.position = new Vector3(25, transform.position.y, transform.position.z);
        }
        if(transform.position.y > 0){
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
         if(transform.position.y < -5){
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
        }
    }
}
