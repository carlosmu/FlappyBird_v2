using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance; // Variable estática para el singleton
    [SerializeField] private AudioClip audioClipCoin; // Audioclip de Coin
    [SerializeField] private AudioClip audioClipFlap; // Audioclip de Flap
    [SerializeField] private AudioClip audioClipHit; // Audioclip de Hit
    [SerializeField] private AudioSource audioSource; // Referencia al audiosource para SFX
    private void Awake()
    {
        // Configuramos el singleton
        if(SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }
        else if(SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayCoin() // Método para llamar al clip de Coin
    {
        PlayAudioClip(audioClipCoin);
    }

    public void PlayFlap() // Método para llamar al clip de Flap
    {
        PlayAudioClip(audioClipFlap);
    }
    public void PlayHit() // Método para llamar al clip de Hit
    {
        PlayAudioClip(audioClipHit);
    }
    private void PlayAudioClip(AudioClip audioClip) // Método para reducir código en los tres anteriores
    {
        audioSource.clip = audioClip; // Asigna el audioclip al audiosource
        audioSource.Play(); // Ejecuta el audioclip
    }

    private void OnDestroy()
    {
        // Si hay una instancia ponerla a null en el destroy
        if(SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
