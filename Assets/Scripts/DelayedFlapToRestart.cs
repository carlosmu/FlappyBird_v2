using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFlapToRestart : MonoBehaviour
{
    [SerializeField] private GameObject flapToRestart; // Referencia al texto de Flap to Restart
    [SerializeField] private float delay = 3f; // Tiempo de espera
    private void OnEnable()
    {
        Invoke("EnableFlapToRestart", delay); // En el OnEnable, invocamos luego de x tiempo el método EnableFlapToRestart
    }

    // Método para activar el texto de flapToRestart.
    private void EnableFlapToRestart()
    {
        flapToRestart.SetActive(true);
    }
   
}
