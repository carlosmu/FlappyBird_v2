using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5; // La cantidad de columnas que aparecerán en la escena a la vez
    [SerializeField] private GameObject columnPrefab; // La referencia al prefab de las columnas
    [SerializeField] private float columnMin = -1.8f; // Posición mínima para abajo de posicionamiento de las columnas
    [SerializeField] private float columnMax = 1.3f; // Posición máxima para arriba de posicionamiento de las columnas
    private float spawnXPosition = 10; // La posición en X donde se spawnea
    private GameObject[] columns; // El array de columnas
    private Vector2 objectPoolPosition = new Vector2(-10,0); // La posición del Pool
    private float timeSinceLastSpawned; // El tiempo acumulado
    [SerializeField] private float spawnRate = 2f; // La taza de spawneo (tiempo de demora)
    private int currentColumn = 0; // La columna actual. Es el índice dentro del array.

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize]; // Asigna el PoolSize al array.

        for (int i=0; i < columnPoolSize; i++) // Para i, si es menor que PoolSize, ejecutar y luego incrementar en 1
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity); // En cada columna instanciar el prefab, la posición y rotación.
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; // Añadir el tiempo que ha pasado desde el último fotograma
        // Si NO es GameOver y tiempo acumulado es igual o mayor a la taza de spawneo
        if(!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate) 
        {
            timeSinceLastSpawned = 0; // Asignar 0
            // Una variable para guardar la posición en Y en cada caso, obtenida aleatoriamente
            float spawnYPosition = Random.Range(columnMin,columnMax); 
            // En el array Columns, a la columna actual, accedemos a su posición, le asignamos los valores en x e y
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition); 
            // En cada iteración le sumamos 1
            currentColumn++;
            // Y..si la columna actual es igual o mayor que el poolsize (en este caso 5), la ponemos en 1
            // Recordar que el índice es 0, 1, 2, 3, 4
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
