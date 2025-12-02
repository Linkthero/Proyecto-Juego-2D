using UnityEngine;

public class Bala : MonoBehaviour
{

    [Header("Ajustes de movimiento")]
    [SerializeField] private int velocidad;

    [Header("Tiempo de vida")]
    [SerializeField] private int tiempoVida;

    private Rigidbody2D rb;

    [Header("Sonidos")]
    [SerializeField] private AudioSource sonidoDisparo;
    [SerializeField] private AudioSource sonidoExplosion;

    [Header("Efectos")]
    [SerializeField] private GameObject efectoImpacto;      //Está comentadoo
    private Disparo disparo; //1 UP, 2 RIGHT, 3 DOWN, 4 LEFT
    private CircleCollider2D col;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sonidoDisparo != null)
        {
            sonidoDisparo.Play();
        }

        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * velocidad;
        col = GetComponent<CircleCollider2D>();
        col.enabled = true;

        Destroy(gameObject, tiempoVida);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            col.enabled = false;
            //if (efectoImpacto != null)
            //{
            //    Instantiate(efectoImpacto, collision.transform.position, Quaternion.identity);
            //}
            //if (sonidoExplosion != null)
            //{
            //    sonidoExplosion.Play();
            //}

            //Datos.instance.AddPoints(collision.gameObject.GetComponent<EnemyMove>().puntos);
            //Datos.instance.MostrarPuntosDinamicos(collision.gameObject.GetComponent<EnemyMove>().puntos, collision.transform.position);

            //Destroy(collision.gameObject);
            //Datos.instance.AumentaEnemigosMuertos();

            
            collision.GetComponent<Enemy>().recibirDaño();
            
                
            Destroy(gameObject, 0.1f);
        }
    }
}
