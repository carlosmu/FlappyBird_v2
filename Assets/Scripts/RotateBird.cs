using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBird : MonoBehaviour
{
    // Mientras más bajo sea este valor, más tarda en inclinarse el pájaro
    [SerializeField] private float maxDownVelocity = -5f; // Máxima velocidad 
    [SerializeField] private float maxDownAngle = -90f; // Máximo ángulo
    private Rigidbody2D rb2D; // Variable para Referencia al Rigidbody

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>(); // Obtenemos la referencia al RB2D
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2D != null) // Si, rigidbody existe..
        {
            // currentVelocity valdrá entre -5 y 0
            float currentVelocity = Mathf.Clamp(rb2D.velocity.y, maxDownVelocity, 0);
            // Obtendremos el ángulo de dividir la velocidad actual / el máximo de velocidad de caída..
            // ..multiplicado por el máximo ángulo de caída. Por ej. 1/1 * 90 = 90
            float angle = (currentVelocity / maxDownVelocity) * maxDownAngle;
            // Ahora tenemos que pasarlo a un Quaternion. Y eso lo hacemos primero con Euler.
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            // Y finalmente asignamos esa rotación a la variable quaternion llamada "rotation".
            transform.rotation = rotation;
        }
    }
}
