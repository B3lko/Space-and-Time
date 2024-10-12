using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class SceneLoadManager : MonoBehaviour{
    [SerializeField] RectTransform leftGear;
    [SerializeField] RectTransform rightGear;
    [SerializeField] RectTransform gear;
    [SerializeField] RectTransform background;
    private bool isReady = false;


    void Start(){
        leftGear.DOAnchorPos(new Vector2(-1600, 0), 2);
        rightGear.DOAnchorPos(new Vector2(1600, 0), 2);
    }


    public void ReadyChangeScene(){
        isReady = true;
    }


    void Update(){
        if(isReady){
            isReady = false;
            leftGear.DOAnchorPos(new Vector2(-480, 0), 2).SetEase(Ease.Linear);
            rightGear.DOAnchorPos(new Vector2(480, 0), 2).SetEase(Ease.Linear).OnComplete(() => {
                gear.gameObject.SetActive(true);
                background.gameObject.SetActive(true);
                gear.DORotate(new Vector3(0, 0, 360), 1, RotateMode.FastBeyond360).SetEase(Ease.OutBack).OnComplete(() => {
                    LoadNextScene();
                });
            });
        }
    }


    private void LoadNextScene(){
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
