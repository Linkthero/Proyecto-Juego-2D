using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public void Reanudar()
    {
        Datos.instance.juegoPausado = false;
        Time.timeScale = 1; //reanuda el juego
        this.gameObject.SetActive(false);
    }

    public void Salir()
    {
        Time.timeScale = 1;
        StartCoroutine(GameObject.FindAnyObjectByType<PasarNivel>().fadeOutDelayNivel("MenuInicial"));        
    }

    public void ReiniciarNivel()
    {
        Datos.instance.GuardarVidas();
        Time.timeScale = 1;
        StartCoroutine(GameObject.FindAnyObjectByType<PasarNivel>().fadeOutDelay());
    }

}
