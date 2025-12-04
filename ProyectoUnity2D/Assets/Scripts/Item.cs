using System.Collections;
using UnityEngine;

public enum Poder { DisparoContinuo, DisparoCruz, Pausa, Bomba, Vida }

public class Item : MonoBehaviour
{

    public Poder tipoPoder;

    public void PoderVida(VidaJugador vidas)
    {
        Datos.instance.vidas++;
        vidas.SetVidas(Datos.instance.vidas);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(tipoPoder == Poder.DisparoContinuo)
            {
                SFXManager.instance.PlayItem();
                collision.GetComponent<Disparo>().PowerUp();
            }
            else if(tipoPoder == Poder.DisparoCruz)
            {
                SFXManager.instance.PlayItem();
                collision.GetComponent<Disparo>().PowerUpDisparoCruz();
            }
            else if(tipoPoder == Poder.Pausa)
            {
                SFXManager.instance.PlayPausa();
                Datos.instance.PowerUpPausa();
                //GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
                //foreach (var e in listaEnemigos)
                //{
                //    e.GetComponent<Enemy>().PowerUpPausa();
                //}
            }
            else if(tipoPoder == Poder.Bomba)
            {
                SFXManager.instance.PlayExplosion();
                GameObject[] listaEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var e in listaEnemigos)
                {
                    e.GetComponent<Enemy>().animator.SetTrigger("Bomba");
                    e.GetComponent<Enemy>().isLive = false;
                    //e.GetComponent<Enemy>().Destruir();       //ya se llama en la animacion
                }
            }
            else if(tipoPoder == Poder.Vida)
            {
                SFXManager.instance.PlayVida();
                PoderVida(collision.GetComponent<VidaJugador>());
            }
            Destroy(gameObject);
        }
    }

}
