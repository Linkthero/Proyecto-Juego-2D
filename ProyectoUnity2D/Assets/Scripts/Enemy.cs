using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int vidas = 1;
    public float speed;
    private float LastSpeed;
    public Rigidbody2D target;

    bool isLive = true;
    private Rigidbody2D rb;
    private SpriteRenderer spriter;
    public Animator animator;

    public float tiempoPowerUp;


    private void Start()
    {
        
        LastSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (Datos.instance.powerUpPausaEnemigos)
        {
            speed = 0;
        }
    }

    private void FixedUpdate()
    {
        if (!isLive)
            return;
        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed *Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.linearVelocity = Vector2.zero;

        if(Datos.instance.powerUpPausaEnemigos)
        {
            speed = 0;
        } else
        {
            speed = LastSpeed;
        }
    }

    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rb.position.x;
    }
    public void recibirDaño()
    {
        
        vidas--;

        if (vidas <= 0)
        {
            DestroyEnemy();
            Datos.instance.AumentaEnemigosMuertos();
        }
        else
        {
            animator.SetTrigger("Hit");
        }           
    }

    // Destruye al enemigo tras un tiempo
    public void DestroyEnemy(float t = 0.16f)
    {
        animator.SetTrigger("muerte");
        //Invoke(nameof(Destruir), t);
    }

    private void Destruir()
    {

        Destroy(gameObject);
    }

    public void PowerUpPausa()
    {
        Datos.instance.powerUpPausaEnemigos = true;
        Invoke(nameof(restaurar), tiempoPowerUp);
    }

    private void restaurar()
    {
        Datos.instance.powerUpPausaEnemigos = false;
    }

}
