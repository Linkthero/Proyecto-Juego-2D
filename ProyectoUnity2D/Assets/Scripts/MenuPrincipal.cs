using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Fade fade;

    private void Start()
    {
        StartCoroutine(fadeIn());
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Jugar()
    {
        fade.gameObject.active = true;
        StartCoroutine(fadeOutDelay());
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
}
