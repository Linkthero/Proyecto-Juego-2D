using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Fade fade;
    [SerializeField] private GameObject panelOpciones;

    private void Start()
    {
        panelOpciones.SetActive(false);
        StartCoroutine(fadeIn());
        if (SceneManager.GetActiveScene().name == "MenuInicial")
        {
            panelOpciones.transform.GetChild(0).GetComponent<Slider>().value = SFXManager.instance.audioSource.volume;
            panelOpciones.transform.GetChild(1).GetComponent<Slider>().value = AudioManager.instance.audioSource.volume;
        }
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        fade.gameObject.active = true;
        StartCoroutine(fadeOutDelay());
        StartCoroutine(AudioManager.instance.FadeOut(1f));
    }

     IEnumerator fadeOutDelay()
    {
        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Nivel 1");
    }

    IEnumerator fadeIn()
    {
        yield return new WaitForSeconds(1f);
        fade.gameObject.active = false;
    }

    public void Reintentar()
    {
        fade.gameObject.active = true;
        GameManager.instance.PrimeraPartida();
        StartCoroutine(fadeOutDelay());
    }

    public void CerrarVentanaOpciones()
    {
        panelOpciones.SetActive(false);
    }

    public void abrirPanelOpciones()
    {
        panelOpciones.SetActive(true);
    }

    public void SetVolumenMusica()
    {
        float v = panelOpciones.transform.GetChild(1).GetComponent<Slider>().value;      //asignamos volumen musica
        AudioManager.instance.audioSource.volume = v;
        AudioManager.instance.volumenMax = v;
    }

    public void SetVolumenSFX()
    {
        float v = panelOpciones.transform.GetChild(0).GetComponent<Slider>().value;      //asignamos volumen sfx
        SFXManager.instance.audioSource.volume = v;
        if(!SFXManager.instance.audioSource.isPlaying)
        {
            SFXManager.instance.PlayItem(); //audio de prueba
        }
        
    }
}
