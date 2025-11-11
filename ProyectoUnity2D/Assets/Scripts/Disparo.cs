using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Disparo : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private GameObject prefabBala;
    [SerializeField] private Transform puntoDisparoDerecha;
    [SerializeField] private Transform puntoDisparoIzquierda;
    private PlayerMovement playerMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }
    public void OnDisparo(InputValue value)
    {
        Debug.Log("Dispara");
    }
    //public void OnDisparo(InputValue valor)
    //{
    //    Debug.Log("Dispara");
    //    if (!valor.isPressed)
    //    {
    //        return;
    //    }
    //    if (prefabBala == null || puntoDisparoDerecha == null || puntoDisparoIzquierda == null)
    //        return;

    //    //if(playerMove.enSuelo)
    //    //    StartCoroutine("CoorDisparo");
    //    StartCoroutine("CoorDisparo");
    //}

    private IEnumerator CoorDisparo()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        if (playerMove.mirandoDerecha)
            Instantiate(prefabBala, puntoDisparoDerecha.position, puntoDisparoDerecha.rotation);
        else
            Instantiate(prefabBala, puntoDisparoIzquierda.position, puntoDisparoIzquierda.rotation);
    }
}
