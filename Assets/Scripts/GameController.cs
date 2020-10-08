using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Definimos un singleton
    public static GameController instance;

    [SerializeField] private GameObject gameOverText; // Referencia al texto de GameOver
    public bool gameOver; // Variable lógica para el Game Over
    public float scrollSpeed = -1.5f; // La velocidad de scroll. La ponemos acá porque a este script podemos acceder desde cualquier script.

    private int score = 0; // Variable para guardar la puntuación

    [SerializeField] Text scoreText; // Variable para referenciar el texto del Score

    private void Awake()
    {
        // Para el singleton. 
        // Si la instancia de GameController es null, asignar esta a la instancia.
        if(GameController.instance == null)
        {
            GameController.instance = this;
        }
        // Sino, si Es distinto a esta, destruir el game Object.
        // Además sacar un Warning para que sepamos que no debería haber dos instancias del objeto
        else if(GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController ha sido instanciado por segunda vez. Esto no debería pasar.");
        }
    }

    // Método público para sumarle puntos al pájaro
    public void BirdScore()
    {
        // Si perdimos, salir de la ejecución
        if (gameOver) return;
        // De lo contrario.. sumar 1 punto.
        score++;
        // E imprimir en el texto "Score " + el valor entero del puntaje.
        scoreText.text = "Score: " + score;
        // Recordar que para usar un singleton debemos usar .instance
        // En este caso estamos instanciando este método desde SoundSystem
        SoundSystem.instance.PlayCoin();
    }

    public void BirdDie() // Método público para poder usarlo desde otros scripts
    {
        gameOverText.SetActive(true); // Cuando el pájaro muere, activar el Game Over
        gameOver = true; // Poner la variable del estado de Game Over en true
    }

    private void OnDestroy()
    {
        // Para cuando cargamos una nueva escena. Cuando se destruye el GameController actual
        // Al destruirse asignarle null, de tal modo a dejarlo listo para la nueva escena.
        if(GameController.instance == this)
        {
            GameController.instance = null;
        }
    }


}
