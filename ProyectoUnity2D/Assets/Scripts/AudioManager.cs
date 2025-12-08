using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] AudioClip musicaMenuPrincipal;
    [SerializeField] AudioClip musicaNivel1;
    [SerializeField] AudioClip musicaNivel2;
    [SerializeField] AudioClip musicaNivel3;
    [SerializeField] AudioClip musicaMenuFinal;
    [SerializeField] AudioClip musicaFinJuego;
    public float volumenMax;

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

        volumenMax = audioSource.volume;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Primero suena la cancion de inicio
        audioSource.clip = musicaMenuPrincipal;
        audioSource.volume = 0;
        audioSource.Play();
        StartCoroutine(FadeIn(1f));
    }


    public void CambiaClip()
    {
        string nombreEscenaActiva = SceneManager.GetActiveScene().name;

        if (nombreEscenaActiva == "Nivel 1")
        {
            audioSource.clip = musicaNivel1;
        }
        else if (nombreEscenaActiva == "Nivel 2")
        {
            audioSource.clip = musicaNivel2;
        }
        else if (nombreEscenaActiva == "Nivel 3")
        {
            audioSource.clip = musicaNivel3;
        }
        else if (nombreEscenaActiva == "Nivel 4")
        {
            audioSource.clip = musicaMenuFinal;
        }
        else if (nombreEscenaActiva == "FinJuego")
        {
            audioSource.clip = musicaFinJuego;
        }
    }

    public void Play()
    {
        audioSource.Play();
    }

    public IEnumerator FadeIn(float duracion)
    {
        //audioSource.Play();
        audioSource.volume = 0;
        float startVolume = volumenMax;
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / duracion;
            yield return null;
        }
    }

    public IEnumerator FadeOut(float duracion)
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
