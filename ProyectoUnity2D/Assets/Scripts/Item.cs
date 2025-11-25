using System.Collections;
using UnityEngine;

public enum Poder { DisparoContinuo, DisparoCruz, Pausa, Bomba, Vida }

public class Item : MonoBehaviour
{

    public Poder tipoPoder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PoderDisparoCruz()
    {

    }

    public void PoderPausa()
    {

    }

    public void PoderBomba()
    {

    }

    public void PoderVida(VidaJugador vidas)
    {
        vidas.SetVidas(Datos.instance.vidas + 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(tipoPoder == Poder.DisparoContinuo)
            {
                collision.GetComponent<Disparo>().PowerUp();
            }
            else if(tipoPoder == Poder.DisparoCruz)
            {
                PoderDisparoCruz();
            }
            else if(tipoPoder == Poder.Pausa)
            {
                GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var e in listaEnemigos)
                {
                    e.GetComponent<Enemy>().PowerUp();
                }
                PoderPausa();
            }
            else if(tipoPoder == Poder.Bomba)
            {
                PoderBomba();
            }
            else if(tipoPoder == Poder.Vida)
            {
                PoderVida(collision.GetComponent<VidaJugador>());
            }
            Destroy(gameObject);
        }
    }

}
