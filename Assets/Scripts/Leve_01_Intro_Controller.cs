using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class Leve_01_Intro_Controller : MonoBehaviour{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Doc;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    private List<string> dialogueLines;
    private bool didDialogueStart = false;
    private int LineIndex;
    private int LineIndexFinish;
    private float TypingTime = 0.05f;



    void Awake() {
        dialogueLines = new List<string>();
        dialogueLines.Add("Finalmente...");
        dialogueLines.Add("Te estaba esperando...");
        dialogueLines.Add("Soy Camarasa, técnico en sincronización de mecanismos de precisión...");
        dialogueLines.Add("...");
        dialogueLines.Add("Osea relojero...");
        dialogueLines.Add("Como te daras cuenta estoy rompiendo la cuarta pared...");
        dialogueLines.Add("Pero tengo un buen motivo para hacerlo...");
        dialogueLines.Add("El creador de este videojuego se cree muy gracioso creando historias ¯\\_(ツ)_/¯");
        dialogueLines.Add("...");
        dialogueLines.Add("Como sea...");
        dialogueLines.Add("Necesito que me ayudes a probar algunos relojes experimentales...");
        dialogueLines.Add("Para eso necesitamos darte un cuerpo dentro de este este mundo...");
        dialogueLines.Add("Que? Es lo unico que puedo conseguir...");
        dialogueLines.Add("Bueno, ahora aprende a usarlo, nos vemos luego...");
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
/*
    private IEnumerator Action_02(){
        characterNameText.text = "";
        foreach(char ch in "Camarasa"){
            characterNameText.text += ch;
            yield return new WaitForSeconds(TypingTime);
        }
        LineIndexFinish = 8;
        StartDialogue(3);
    }*/


    public void StartDialogue(int LIndex){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
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
            Debug.Log("SI");
            Player.SetActive(true);
            Player.GetComponent<PlayerController>().SetMove(false);
            //didDialogueStart = false;
            //dialoguePanel.SetActive(false);
        }
        else {
            StartCoroutine(ShowLine());
        }

    }


    void Update(){
        if(didDialogueStart ){

        if(Input.GetButtonDown("Fire1")){
            /*if(!didDialogueStart){
                StartDialogue();
            }
            else*/ if(dialogueText.text == dialogueLines[LineIndex]){
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
