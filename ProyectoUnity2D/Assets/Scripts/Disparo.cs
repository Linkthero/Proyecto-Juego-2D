using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Threading;

public class Disparo : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private GameObject prefabBala;

    [Header("Puntos de disparo")]
    [SerializeField] private Transform puntoDisparoArriba;
    [SerializeField] private Transform puntoDisparoAbajo;
    [SerializeField] private Transform puntoDisparoDerecha;
    [SerializeField] private Transform puntoDisparoIzquierda;

    //Disparos diagonales
    [SerializeField] private Transform puntoDisparoDerUp;
    [SerializeField] private Transform puntoDisparoDerDown;
    [SerializeField] private Transform puntoDisparoIzqUp;
    [SerializeField] private Transform puntoDisparoIzqDown;

    private PlayerMovement playerMove;
    private Animator animator;
    [SerializeField] public float tiempoDisparo = 0.5f;
    private float disparonext = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.time > disparonext)
        {
            //DISPARO DIAGONAL
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetTrigger("DisparoRight");
                //Debug.Log("Hago disparo diagonal");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.RightArrow, KeyCode.UpArrow));
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetTrigger("DisparoRight");
                //Debug.Log("Hago disparo diagonal");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.RightArrow, KeyCode.DownArrow));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetTrigger("DisparoLeft");
                //Debug.Log("Hago disparo diagonal");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.LeftArrow, KeyCode.DownArrow));
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetTrigger("DisparoLeft");
                //Debug.Log("Hago disparo diagonal");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.LeftArrow, KeyCode.UpArrow));
            }
            //Disparo direcciones
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetTrigger("DisparoUp");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.UpArrow));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetTrigger("DisparoDown");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.DownArrow));
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetTrigger("DisparoLeft");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.LeftArrow));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetTrigger("DisparoRight");
                disparonext = Time.time + tiempoDisparo;
                StartCoroutine(CoorDisparo(KeyCode.RightArrow));
            }
        }
    }
    //public void OnDisparo(InputValue value)
    //{
        
       
    //}
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

    private IEnumerator CoorDisparo(KeyCode k, KeyCode j = KeyCode.None)
    {
        yield return new WaitForSecondsRealtime(0.2f);
        if (k == KeyCode.RightArrow && j == KeyCode.UpArrow) //DISPAROS DIAGONALES
        {
            Instantiate(prefabBala, puntoDisparoDerUp.position, puntoDisparoDerUp.rotation);
        }
        else if (k == KeyCode.RightArrow && j == KeyCode.DownArrow)
        {
            Instantiate(prefabBala, puntoDisparoDerDown.position, puntoDisparoDerDown.rotation);
        }
        else if (k == KeyCode.LeftArrow && j == KeyCode.DownArrow)
        {
            Instantiate(prefabBala, puntoDisparoIzqDown.position, puntoDisparoIzqDown.rotation);
        }
        else if (k == KeyCode.LeftArrow && j == KeyCode.UpArrow)
        {
            Instantiate(prefabBala, puntoDisparoIzqUp.position, puntoDisparoIzqUp.rotation);
        } else if (k == KeyCode.UpArrow)
        {
            Instantiate(prefabBala, puntoDisparoArriba.position, puntoDisparoArriba.rotation);
        }
        else if (k == KeyCode.DownArrow)
        {
            Instantiate(prefabBala, puntoDisparoAbajo.position, puntoDisparoAbajo.rotation);
        }
        else if (k == KeyCode.LeftArrow)
        {
            Instantiate(prefabBala, puntoDisparoIzquierda.position, puntoDisparoIzquierda.rotation);
        } else if (k == KeyCode.RightArrow)
        {
            Instantiate(prefabBala, puntoDisparoDerecha.position, puntoDisparoDerecha.rotation);
        } 
    }
}
