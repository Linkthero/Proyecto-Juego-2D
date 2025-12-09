using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour
{

    [Header("Imagen")]
    [SerializeField] private TextMeshProUGUI txtVidas;

    public int vidasActuales;


    private void Start()
    {
        Datos.instance.RestaurarVidas();
        SetVidas(Datos.instance.GetVidas());    
    }

    public void SetVidas(int vidas)
    {
        vidasActuales = vidas;
        txtVidas.text = "x " + vidasActuales;
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
