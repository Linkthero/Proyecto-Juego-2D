using System;
using UnityEngine;

public class EnemigoSlime : Enemy
{
    private bool pinchos = false;
    private new void Start()
    {
        base.Start();
        int inicio = UnityEngine.Random.Range(10, 15);
        int siguiente = UnityEngine.Random.Range(5, 15);

        InvokeRepeating("Pinchos", inicio, siguiente);
    }

    private new void FixedUpdate()
    {
        if (!isLive)
            return;

        if (Datos.instance.powerUpPausaEnemigos || pinchos)
        {
            speed = 0;
        }
        else
        {
            speed = LastSpeed;
        }

        Vector2 dirVec = target.position - rb.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + nextVec);
        rb.linearVelocity = Vector2.zero;

    }

    private void Pinchos()
    {
        pinchos = true;
        animator.SetTrigger("Pinchos");
    }

    public void setPinchosFalse()
    {
        pinchos = false;
    }
}
