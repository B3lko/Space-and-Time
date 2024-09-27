using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level_01_Controller : MonoBehaviour{
    [SerializeField] private GameObject BtnNext;
    [SerializeField] private GameObject BtnMenu;
    [SerializeField] private GameObject BtnRetry;
    [SerializeField] private GameObject BtnNext2;
    [SerializeField] private GameObject BtnMenu2;
    [SerializeField] private GameObject BtnRetry2;
    [SerializeField] private GameObject Pause1;
    [SerializeField] private GameObject Pause2;
    [SerializeField] public GameObject Black;
    [SerializeField] public GameObject Black2;
    [SerializeField] public GameObject InfoBar;
    public GameObject TimeTxt;
    public GameObject DeathsTxt;
    public GameObject DeathsFinishTxt;
    public GameObject TimeFinishTxt;
    public int index;
    public int deaths = 0;
    float timeStep = 0.1f;
    private float time = 0;
    public bool isEnd = false;

    void Update(){
        if(!isEnd){
            time += timeStep * Time.deltaTime * 10;
            TimeTxt.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F0");
        }

        if(BtnMenu.GetComponent<pressbtn>().press == true || BtnMenu2.GetComponent<pressbtn>().press == true){
            BtnMenu.GetComponent<pressbtn>().press = false;
            BtnMenu2.GetComponent<pressbtn>().press = false;
            SceneManager.LoadScene("MainMenu");
        }
        if(BtnRetry.GetComponent<pressbtn>().press == true || BtnRetry2.GetComponent<pressbtn>().press == true){
            BtnRetry.GetComponent<pressbtn>().press = false;
            BtnRetry2.GetComponent<pressbtn>().press = false;
            switch(index){
                case 1: SceneManager.LoadScene("Level_01");break;
                case 2: SceneManager.LoadScene("Level_02");break;
                case 3: SceneManager.LoadScene("Level_03");break;
            }
        }
        if(BtnNext.GetComponent<pressbtn>().press == true || BtnNext2.GetComponent<pressbtn>().press == true){
            BtnNext.GetComponent<pressbtn>().press = false;
            BtnNext2.GetComponent<pressbtn>().press = false;
            switch(index){
                case 1: SceneManager.LoadScene("Level_02");break;
                case 2: SceneManager.LoadScene("Level_03");break;
                case 3: SceneManager.LoadScene("Level_03");break;
            }
        }
        if(Pause1.GetComponent<pressbtn>().press == true){
            Pause1.GetComponent<pressbtn>().press = false;
            Black2.SetActive(true);
            isEnd = true;
        }
        if(Pause2.GetComponent<pressbtn>().press == true){
            Pause2.GetComponent<pressbtn>().press = false;
            Black2.SetActive(false);
            isEnd = false;
        }
    }

    public void SetDeaths(){
        deaths += 1;
        DeathsTxt.GetComponent<TextMeshProUGUI>().text = "Deaths: " + (deaths).ToString();
    }

    public void SetFinish(){
        isEnd = true;
        InfoBar.SetActive(false);
        DeathsFinishTxt.GetComponent<TextMeshProUGUI>().text = "Deaths: " + (deaths).ToString();
        TimeFinishTxt.GetComponent<TextMeshProUGUI>().text = "Time: " + time.ToString("F0");
        Black.SetActive(true);
    }
}
