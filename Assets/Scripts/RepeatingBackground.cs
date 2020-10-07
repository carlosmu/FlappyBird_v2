using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider; // Variable para referenciar el BoxCollider.
    private float groundHorizontalLength; // Variable para guardar el largo del BoxCollider en x.

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>(); // Asignamos el componente a la variable.
    }
    // Start is called before the first frame update
    void Start()
    {
        groundHorizontalLength = groundCollider.size.x; // Asignamos el largo en x del collider a nuestra variable.
    }

    // Método para reposicionar el Background
    private void RepositionBackground()
    {
        // Mover el transform, multiplicando el vector por el largo horizontal por dos.
        transform.Translate(Vector2.right * groundHorizontalLength * 2);
    }

    // Update is called once per frame
    void Update()
    {
        // Si la posición en el transform en x es menor a el largo horizontal del suelo (en negativo)..
        // Reposicionar Background. 
        // Y como cada "Ground" tiene el script, cada uno lo hace a su tiempo.
        if(transform.position.x < -groundHorizontalLength)
        {
            RepositionBackground();
        }
    }
}
