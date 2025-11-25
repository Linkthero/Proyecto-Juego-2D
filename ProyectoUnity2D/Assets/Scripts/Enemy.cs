using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    }

    private void LateUpdate()
    {
        if (!isLive)
            return;
        spriter.flipX = target.position.x < rb.position.x;
    }

    public void DestroyEnemy()
    {
        animator.Play("Hit");
        Destroy(gameObject);
    }

    public void PowerUp()
    {
        speed = 0;
        Datos.instance.powerUpPausaEnemigos = true;
        Invoke(nameof(restaurar), tiempoPowerUp);
    }

    private void restaurar()
    {
        speed = LastSpeed;
        Datos.instance.powerUpPausaEnemigos = false;
    }
}
