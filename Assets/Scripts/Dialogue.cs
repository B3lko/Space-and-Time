using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    //private string[] dialogueLines;
    List<string> dialogueLines;
    private bool didDialogueStart = false;
    private int LineIndex;
    private float TypingTime = 0.05f;


    void Awake() {
        dialogueLines = new List<string>();
        dialogueLines.Add("Te estaba esperando");
        dialogueLines.Add("Como te llamas?");
        dialogueLines.Add("Mi nombre es Camarasa, soy el relojero del pueblo! Gusto en conocerte");
        //dialogueLines.Add("Bienvenido: Como es tu nombre?");
        //dialogueLines.Add("Bienvenido: Como es tu nombre?");
        //dialogueLines[1] = "Hola *Nombre*, como estas? Soy Camarasa el relojero del pueblo! Gusto en conocerte";
        //dialogueLines[2] = "Bueno, si a vos te gusta ¯|_(ツ)_/¯";
    }


    public void StartDialogue(){
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        LineIndex = 0;
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
        if(LineIndex < dialogueLines.Count){
            StartCoroutine(ShowLine());
        }
        else{
            didDialogueStart = false;
            dialoguePanel.SetActive(false);

        }
    }


    void Update(){
        if(Input.GetButtonDown("Fire1")){
            if(!didDialogueStart){
                StartDialogue();
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
