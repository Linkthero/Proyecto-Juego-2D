using System;
using UnityEngine;

public class EnemigoSlime : Enemy
{
    private bool pinchos = false;
    private new void Start()
    {
        base.Start();
        int inicio = UnityEngine.Random.Range(5, 15);
        int siguiente = UnityEngine.Random.Range(10, 15);

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

    //public void recibirDaño()
    //{
    //    if(pinchos)
    //    {
    //        base.recibirDaño();
    //    }
    //}

    private void Pinchos()
    {
        pinchos = true;
        animator.SetTrigger("Pinchos");
        rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation; //congela posicion
    }

    public void setPinchosFalse()
    {
        pinchos = false;
        //vuelve a poner los constrains normales
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public bool GetPinchos()
    {
        return pinchos;
    }
}
