using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class Leve_01_Intro_Controller : MonoBehaviour{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject cam;
    [SerializeField] GameObject Doc;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private GameObject Tuto_01;
    private List<string> dialogueLines;
    private bool didDialogueStart = false;
    private int LineIndex;
    private int LineIndexFinish;
    private float TypingTime = 0.05f;
    private bool finish = false;



    void Awake() {
        dialogueLines = new List<string>();
        dialogueLines.Add("Finalmente...");
        dialogueLines.Add("Te estaba esperando...");
        dialogueLines.Add("Me presento: soy técnico en sincronización de mecanismos de precisión...");
        dialogueLines.Add("...");
        dialogueLines.Add("Osea relojero...");
        dialogueLines.Add("Como te daras cuenta estoy rompiendo la cuarta pared...");
        dialogueLines.Add("Pero tengo un buen motivo para hacerlo...");
        dialogueLines.Add("El creador de este videojuego se cree muy gracioso creando historias...");
        dialogueLines.Add("...");
        dialogueLines.Add("Como sea...");
        dialogueLines.Add("Necesito que me ayudes a probar algunos relojes experimentales...");
        dialogueLines.Add("Para eso necesitamos darte un cuerpo dentro de este este mundo...");
        dialogueLines.Add("Que? Es lo unico que puedo conseguir...");
        dialogueLines.Add("como sea, aprende a usarlo y luego nos encontramos...");
    }


    void Start(){
        Action_01();
    }


    private void Action_01(){
        Doc.transform.DOMoveX(0,3).OnComplete(() => {
            LineIndexFinish = 11;
            StartDialogue(0);
        });
    }


    public void StartDialogue(int LIndex){
        didDialogueStart = true;
        LineIndex = LIndex;
        StartCoroutine(ShowLine());
    }


    private IEnumerator ShowLine(){
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[LineIndex]){
            dialogueText.text += ch;
            yield return new WaitForSeconds(TypingTime);
        }
    }


    private void NextDialogueLine(){
        LineIndex++;
        if(LineIndex == LineIndexFinish + 1){
            Player.SetActive(true);
            Player.GetComponent<PlayerController>().SetMove(false);
        }
        else {
            StartCoroutine(ShowLine());
        }
    }


    void Update(){
        if(didDialogueStart){
            if(Input.GetButtonDown("Fire1") && !finish){
                if(dialogueLines.Count == LineIndex + 1){
                    finish = true;
                    dialogueText.transform.DOScale(0,2);
                    Doc.transform.DOMoveX(15,3).OnComplete(() => {
                        Doc.SetActive(false);
                        Tuto_01.transform.DOMoveX(0, 2).OnComplete(() => {
                            Player.GetComponent<PlayerController>().SetMove(true);
                            cam.GetComponent<CameraController_Intro>().enabled = true;
                        });
                    });
                }
                else if(dialogueText.text == dialogueLines[LineIndex]){
                    NextDialogueLine();
                }
                else{
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[LineIndex];
                }
            }
        }
    }


}
