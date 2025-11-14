using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollider : MonoBehaviour
{

    [SerializeField] private float tiempoEspera;
    private PlayerMovement playerMove;
    private Animator animator;
    private VidaJugador playerLifes;
    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoMuerte;
    private bool inmune = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        playerLifes = GetComponent<VidaJugador>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!inmune)
                StartCoroutine(PararYReiniciar());
        }
    }

    private IEnumerator PararYReiniciar()
    {
        inmune = true;
        playerMove.Parar();
        animator.SetTrigger("Muerte");
        //Datos.instance.vidas--;
        playerLifes.PierdeVida();
        //sonidoMuerte.Play();
        //pa.Muerte();
        
        if (Datos.instance.vidas <= 0)
        {
            //carga pantalla de fin de juego   
            yield return new WaitForSecondsRealtime(tiempoEspera);
            SceneManager.LoadScene("FinJuego");
            inmune =false;
        }
        else
        {
            //vuelve a cargar el nivel pero con una vida menos
            yield return new WaitForSecondsRealtime(tiempoEspera);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            inmune = false;
        }

        //Time.timeScale = 0;
        //inhabilita que se pueda mover
        //playerMove.Parar();
        //yield return new WaitForSecondsRealtime(tiempoEspera);
        //Time.timeScale = 1;
    }
}
