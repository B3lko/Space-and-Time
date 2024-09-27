using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour{  
    public float speed = 1.0f;
    public string[] orderDirections;
    public float[] distances = new float[4];
    private Vector3[] directions;
    private int indexDirections = 0;
    private Vector3 initialPosition;
    private Vector3 destination;
    private bool isMoving = false;
    private Animator animator;
    public GameObject LevelController;

    void Start(){
        animator = GetComponent<Animator>();
        animator.speed = 0f;
        initialPosition = transform.position;

        // Configura las direcciones en función del orden especificado
        directions = new Vector3[orderDirections.Length];
        for (int i = 0; i < orderDirections.Length; i++){
            directions[i] = ObtenerDireccion(orderDirections[i]);
        }

        // Calcula el primer destino basado en la primera dirección
        destination = initialPosition + directions[indexDirections] * distances[indexDirections];
    }

    void Update(){
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !LevelController.GetComponent<Level_01_Controller>().isEnd){
            isMoving = true;
            animator.speed = 1f;
        }
        else{
            isMoving = false;
            animator.speed = 0f;
        }

        if (isMoving){
            Vector3 desplazamiento = (destination - transform.position).normalized * speed * Time.deltaTime;
            transform.Translate(desplazamiento);
            if (Vector3.Distance(transform.position, destination) <= 0.1f){
                transform.position = destination;
                indexDirections = (indexDirections + 1) % directions.Length;
                destination = transform.position + directions[indexDirections] * distances[indexDirections];
            }
        }
    }
    private Vector3 ObtenerDireccion(string nombreDireccion){
        switch (nombreDireccion.ToLower()){
            case "up": return Vector3.up;
            case "down": return Vector3.down;
            case "left": return Vector3.left;
            case "right": return Vector3.right;
            default: return Vector3.zero;
        }
    }
}
