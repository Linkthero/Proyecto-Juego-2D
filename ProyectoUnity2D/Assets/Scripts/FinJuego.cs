using UnityEngine;
using UnityEngine.SceneManagement;

public class FinJuego : MonoBehaviour
{
    public void Reintentar()
    {
        GameManager.instance.PrimeraPartida();
        SceneManager.LoadScene("Nivel 1");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
