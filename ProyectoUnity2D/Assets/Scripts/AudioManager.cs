using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip musicaMenuPrincipal;
    [SerializeField] AudioClip musicaNivel1;
    [SerializeField] AudioClip musicaNivel2;
    [SerializeField] AudioClip musicaNivel3;
    [SerializeField] AudioClip musicaMenuFinal;
    [SerializeField] AudioClip musicaFinJuego;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource.clip = musicaMenuPrincipal;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Datos.instance != null)
        {
            switch(Datos.instance.nivel)
            {
                case 1:
                    audioSource.clip = musicaNivel1;
                    break;
                case 2:
                    audioSource.clip = musicaNivel2;
                    break;
                case 3:
                    audioSource.clip = musicaNivel3;
                    break;
            }
        }
    }

    IEnumerator FadeIn(float duracion)
    {
        audioSource.Play();
        audioSource.volume = 0;
        float startVolume = 1.0f; // Ajustar según volumen deseado
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / duracion;
            yield return null;
        }
    }

    IEnumerator FadeOut(float duracion)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duracion;
            yield return null;
        }

        audioSource.Stop();
    }
}
