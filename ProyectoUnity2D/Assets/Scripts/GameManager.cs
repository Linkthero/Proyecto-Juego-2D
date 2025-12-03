using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private string file;
    public DatosJuego datosJuego;

    private int maxVidas = 3;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //la primera vez q se ejecuta le asignamos el max vidas
            //PrimeraPartida();
            file = Application.persistentDataPath + "/GameData.json";
            PrimeraPartida();
        }
    }

    public void PrimeraPartida()
    {
        DatosJuego dj = new DatosJuego();
        dj.vidas = maxVidas;
        SaveGame(dj);
        Debug.Log("Guardamos vidas)");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SaveGame(DatosJuego datosJuego)
    {
        string json = JsonUtility.ToJson(datosJuego);
        File.WriteAllText(file, json);
    }

    public DatosJuego CargarDatos()
    {
        if (File.Exists(file))
        {
            string contenido = File.ReadAllText(file);
            datosJuego = JsonUtility.FromJson<DatosJuego>(contenido);
        } else
        {
            datosJuego.vidas = 0;
        }
        return datosJuego;

    }

}
