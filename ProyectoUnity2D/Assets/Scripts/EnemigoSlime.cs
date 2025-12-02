using System;
using UnityEngine;

public class EnemigoSlime : Enemy
{
    private void Start()
    {
        int inicio = UnityEngine.Random.Range(2, 10);
        int siguiente = UnityEngine.Random.Range(5, 15);
        InvokeRepeating("Pinchos", inicio, siguiente);
    }

    private void Pinchos()
    {
        animator.SetTrigger("Pinchos");
    }
}
