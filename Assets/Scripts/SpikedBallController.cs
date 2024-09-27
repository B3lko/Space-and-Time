using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBallController : MonoBehaviour{
    public float amplitude = 45f; // Ángulo inicial
    public float frequency = 1f; // Frecuencia del péndulo
    public float pivotX = 0f; // Coordenada X del punto de pivote
    public float pivotY = 0f; // Coordenada Y del punto de pivote
    public float length = 5f; // Longitud del péndulo
    private bool isMoving = false;
    private float elapsedTime = 0f; // Tiempo acumulado mientras el péndulo está en movimiento
    private Vector3 puntoAnclaje; // Punto de anclaje al que está conectada la cadena
    public GameObject eslabonPrefab; // Prefab del eslabón de la cadena
    public int numEslabones = 10; // Número de eslabones en la cadena
    private GameObject[] eslabones; // Array que almacena las instancias de los eslabones
    public GameObject LevelController;


    void Start() {
        puntoAnclaje = new Vector3(pivotX, pivotY, 0);
        // Inicializar el array de eslabones
        eslabones = new GameObject[numEslabones];
        // Instanciar los eslabones
        for (int i = 0; i < numEslabones; i++){
            eslabones[i] = Instantiate(eslabonPrefab, transform.position, Quaternion.identity);
        }
        elapsedTime += Time.deltaTime; // Añadir el tiempo transcurrido al tiempo acumulado
        float angle = amplitude * Mathf.Cos(frequency * elapsedTime);
        float x = pivotX + length * Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = pivotY - length * Mathf.Cos(angle * Mathf.Deg2Rad);
        transform.position = new Vector3(x, y, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        for (int i = 0; i < numEslabones; i++){
            float t = (float)(i + 1) / (float)(numEslabones + 1); // Factor de interpolación entre el punto de anclaje y la bola
            Vector3 position = Vector3.Lerp(puntoAnclaje, transform.position, t);
            eslabones[i].transform.position = position;
        }
    }
    private void Update(){
        // Verificar si se está presionando alguna tecla
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !LevelController.GetComponent<Level_01_Controller>().isEnd){
            isMoving = true;
        }
        else{ isMoving = false; }

        // Si el péndulo está en movimiento, calcular el ángulo
        if (isMoving){
            elapsedTime += Time.deltaTime; // Añadir el tiempo transcurrido al tiempo acumulado
            float angle = amplitude * Mathf.Cos(frequency * elapsedTime);
            float x = pivotX + length * Mathf.Sin(angle * Mathf.Deg2Rad);
            float y = pivotY - length * Mathf.Cos(angle * Mathf.Deg2Rad);
            transform.position = new Vector3(x, y, 0f);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            for (int i = 0; i < numEslabones; i++){
                float t = (float)(i + 1) / (float)(numEslabones + 1); // Factor de interpolación entre el punto de anclaje y la bola
                Vector3 position = Vector3.Lerp(puntoAnclaje, transform.position, t);
                eslabones[i].transform.position = position;
            }
        }
    }
}
