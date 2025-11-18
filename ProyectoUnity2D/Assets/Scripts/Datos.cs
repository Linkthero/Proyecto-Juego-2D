using TMPro;
using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos instance;
    public int nivel;

    [Header("Vidas")]
    [SerializeField] public int maxVidas = 3;
    public int vidas;

    [Header("Enemigos")]
    [SerializeField] private TextMeshProUGUI txtEnemigos;
    private int enemigosMuertos;
    public int enemigosSpawneados;
    [SerializeField] public int nEnemigosOleada1;
    [SerializeField] public int nEnemigosOleada2;
    [SerializeField] public int nEnemigosOleada3;

    public bool siguienteNivel = false;

    private void Awake()
    {
        siguienteNivel = false;
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            vidas = maxVidas;
            nivel = 1;
        }
    }


    public int GetVidas()
    {
        return vidas;
    }

    public void SetVidas(int v)
    {
        vidas = v;
    }

    public int GetEnemigosMuertos()
    {
        return enemigosMuertos;
    }

    public void SetEnemigosMuertos(int e)
    {
        enemigosMuertos = e;
    }

    public void AumentaEnemigosMuertos()
    {
        enemigosMuertos++;
        txtEnemigos.text = enemigosMuertos.ToString();
    }

    public int GetEnemigosDerrotados()
    {
        return enemigosMuertos;
    }
    
    public int GetNivel()
    {
        return nivel;
    }

    public void SetNivel(int n)
    {
        nivel = n;
    }

    private void Update()
    {
        if (nivel == 1)
        {
            if (enemigosMuertos == nEnemigosOleada1)
            {
                siguienteNivel = true;
                nivel++;
            }
        }
        else if (nivel == 2)
        {
            if (enemigosMuertos == nEnemigosOleada2)
            {
                siguienteNivel = true;
                nivel++;
            }
        }
        else
        {
            if (enemigosMuertos == nEnemigosOleada3)
            {
                siguienteNivel = true;
                nivel++;
            }
            //fin de juego
        }
    }
}
