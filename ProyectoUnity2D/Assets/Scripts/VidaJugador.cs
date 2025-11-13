using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{

    [Header("Imagen")]
    [SerializeField] private Image corazones;

    public int vidasActuales;

    private void Awake()
    {
        //maxVidas = Mathf.Clamp(maxVidas, 0, corazones.Count);
        SetVidas(Datos.instance.GetVidas());
    }

    public void SetVidas(int vidas)
    {
        vidasActuales = vidas;
    }

    public void PierdeVida(int cantidad = 1)
    {
        vidasActuales = vidasActuales - cantidad;
        Datos.instance.SetVidas(vidasActuales);
    }

    public void GanarVida(int cantidad = 1)
    {
        vidasActuales = vidasActuales + cantidad;
        Datos.instance.SetVidas(vidasActuales);
    }

    public int GetVidasActuales()
    {
        return vidasActuales;
    }

}
