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
            
            yield return new WaitForSecondsRealtime(tiempoEspera);
            SceneManager.LoadScene("FinJuego");
        }
        else
        {
            yield return new WaitForSecondsRealtime(tiempoEspera);
            Datos.instance.SetVidas(Datos.instance.maxVidas);
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
