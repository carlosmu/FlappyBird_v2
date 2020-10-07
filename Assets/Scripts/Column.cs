using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    // Creamos este método para saber cuándo se activa el trigger del collider de puntos.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameController.instance.BirdDie();
        }
    }
}
