using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{    
    private bool isDead = false; // Variable que guarda el valor de está vivo o muerto     
    private Rigidbody2D rb2d; // Variable que guarda el Rigidbody del pájaro
    private Animator anim; // Referencia al animator
    [SerializeField] private float upForce = 200f; // Impulso del salto para arriba 
    //[SerializeField] GameController gameController;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Referencia al RigidBody
        anim = GetComponent<Animator>(); // Referencia al animator

    }
    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Si no dice "private o public" quiere decir que es privada.
    void Update()
    {
        if (isDead) return; // Si está muerto, terminar la ejecución
        
        if (Input.GetMouseButton(0)) // Si está presionado el botón izquierdo del mouse
        {
            rb2d.velocity = Vector2.zero; // Ponemos su velocidad en 0 antes del impulso
            rb2d.AddForce(Vector2.up * upForce); // Agregamos una fuerza, solo en Y (1), multiplicada por la variable
            anim.SetTrigger("Flap"); // Activa el animator, estado "Flap".
        }    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true; // Si colisiona con un collider, muere
        anim.SetTrigger("Die");
        // gameController.BirdDie(); Esto al final no lo usamos porque vamos a usar un Singleton.
        // Llamamos al singleton y al método "BirdDie".
        GameController.instance.BirdDie();
    }
}
