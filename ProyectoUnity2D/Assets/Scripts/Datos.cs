using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datos : MonoBehaviour
{
    public static Datos instance;
    public int nivel;

    [Header("Vidas")]
    [SerializeField] public int maxVidas = 3;
    public int vidas;

    [Header("Enemigos")]
    [SerializeField] private TextMeshProUGUI txtEnemigos;
    public int enemigosMuertos;
    public int enemigosSpawneados;
    [SerializeField] public int nEnemigosOleada;
    //[SerializeField] public int nEnemigosOleada2;
    //[SerializeField] public int nEnemigosOleada3;

    [Header("PowerUps")]
    [SerializeField] public float tiempoPowerUpPausa;
    public bool powerUpPausaEnemigos = false;
    public bool powerUpDisparoCruz = false;

    public bool siguienteNivel = false;

    public GameManager gameManager;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

        if (SceneManager.GetActiveScene().name != "FinJuego" && SceneManager.GetActiveScene().name != "Nivel 4")
        {

            //obtenemos nivel donde estamos
            nivel = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
            txtEnemigos = GameObject.Find("txtEnemigos").GetComponent<TextMeshProUGUI>();
            //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager = GameManager.instance;
        }
        SFXManager.instance.playedSiguienteNivel = false;
        AudioManager.instance.CambiaClip();
        AudioManager.instance.Play();
        //inicializamos vidas aqui pq en el start puede dar problemas 
        // al inicializar el texto de vidas
        //if (nivel == 1)
        //{
        //    vidas = maxVidas;
        //}
        //else
        //{
        //    RestaurarVidas();
        //}
    }

    public void Start()
    {
        siguienteNivel = false;
        //RestaurarVidas();
    }

    public void RestaurarVidas()
    {
        DatosJuego datosLeidos = gameManager.CargarDatos();
        vidas = datosLeidos.vidas;
        Debug.Log("Se restauran vidas: " + datosLeidos.vidas);
    }

    public void GuardarVidas()
    {
        DatosJuego datosAGuardar = new DatosJuego();
        datosAGuardar.vidas = vidas;
        gameManager.SaveGame(datosAGuardar);
        Debug.Log("Se guardan vidas: " + datosAGuardar.vidas);
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

    public void restaurarDatosAlMorir()
    {
        GuardarVidas();
        //enemigos 
        enemigosMuertos = 0;
        enemigosSpawneados = 0;

        //powerUps
        powerUpDisparoCruz = false;
        powerUpPausaEnemigos = false;

    }

    private void Update()
    {
        // if (nivel == 1)
        ////{
        if (enemigosMuertos == nEnemigosOleada)
        {
            siguienteNivel = true;
            //nivel++;
        }

    }
    public void PowerUpPausa()
    {
        Datos.instance.powerUpPausaEnemigos = true;
        Invoke(nameof(restaurar), tiempoPowerUpPausa);
    }

    private void restaurar()
    {
        Datos.instance.powerUpPausaEnemigos = false;
    }

    //Carga el nivel indicado
    public void CargarNivel(int n)
    {
        Datos.instance.nivel = n;
        SceneManager.LoadScene("Nivel " + Datos.instance.GetNivel().ToString());
    }
}
