using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{    
    private Rigidbody2D rb2d; // Variable para referenciar el RigidBody 2d

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Tomamos la referencia del RigidBody2D
    }
    // Start is called before the first frame update
    void Start()
    {
        // Asignamos la velocidad multiplicando el vector por la variable que tenemos para ello en el GameController.
        rb2d.velocity = Vector2.right * GameController.instance.scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Si perdimos, que no se mueva más el fondo.
        if (GameController.instance.gameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
