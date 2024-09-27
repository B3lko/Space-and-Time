using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour{
    public Transform startingPoint;
    public Transform finalPoint;
    public float speed = 1.0f;
    private float totalDistance;
    private Vector3 initialPosition;
    private bool isMoving = false;
    private float elapsedTime = 0f; // Tiempo acumulado mientras el péndulo está en movimiento
    private Animator animator;
    public GameObject LevelController;


    void Start(){
        // Calcula la distancia entre los puntos inicial y final
        totalDistance = Vector3.Distance(startingPoint.position, finalPoint.position);
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
        animator.speed = 0f;
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

        // Si el péndulo está en movimiento, calcular el ángulo
        if (isMoving){
            elapsedTime += Time.deltaTime; // Añadir el tiempo transcurrido al tiempo acumulado

            // Calcula la posición actual usando la función coseno
            float distanciaRecorrida = Mathf.PingPong(elapsedTime * speed, totalDistance);
            float t = distanciaRecorrida / totalDistance;
            Vector3 nuevaPosicion = Vector3.Lerp(startingPoint.position, finalPoint.position, t);

            // Mueve la plataforma en el eje x
            transform.position = new Vector3(nuevaPosicion.x, transform.position.y, transform.position.z);
        }
        
    }
}
