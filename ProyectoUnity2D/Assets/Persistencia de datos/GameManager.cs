using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private string file;
    public GameDate datosJuego;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        file = Application.persistentDataPath + "/GameData.json";
        datosJuego = new GameDate();
    }

    public void SaveGame(GameDate datosJuego)
    {
        string json = JsonUtility.ToJson(datosJuego);
        File.WriteAllText(file, json);
    }

    public GameDate CargarDatos()
    {
        if (File.Exists(file))
        {
            string contenido = File.ReadAllText(file);
            datosJuego = JsonUtility.FromJson<GameDate>(contenido);
        } else
        {
            datosJuego.x = 0;
            datosJuego.y = 0;
        }
        return datosJuego;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
