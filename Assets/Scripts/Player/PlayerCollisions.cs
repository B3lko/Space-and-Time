using UnityEngine;

public class PlayerCollisions : MonoBehaviour{
    [SerializeField] GameObject sceneLoadManager;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Finish"){
            sceneLoadManager.GetComponent<SceneLoadManager>().ReadyChangeScene();
        }
    }
}
