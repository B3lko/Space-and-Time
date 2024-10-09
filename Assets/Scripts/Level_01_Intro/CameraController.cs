using UnityEngine;

public class CameraController_Intro : MonoBehaviour{
    [SerializeField] Transform player;
    void Start(){
        
    }

// player.position.y
    void Update(){
        transform.position = new Vector3(player.position.x, player.position.y + 1, transform.position.z);
        if(transform.position.x < 0){
            transform.position = new Vector3(0, player.position.y + 1, transform.position.z);
        }
    }


}
