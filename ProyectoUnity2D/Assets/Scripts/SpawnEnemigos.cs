using System.Collections;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    //array de enemigos
    public GameObject[] enemies;

    //tiempo q pasa para spawnear
    public float timeSpawn = 1;

    //se crea un enemigo cada x seg
    private float repeatSpawnRate;


    //bordes, areas q delimitan

    [SerializeField] public Transform xRangeLeft;
    [SerializeField] public Transform xRangeRight;

    [SerializeField]  public Transform yRangeUp;
    [SerializeField]  public Transform yRangeDown;


    void Start()
    {
        repeatSpawnRate = (float)Random.Range(5, 10);
        //StartCoroutine(Example());
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
        if (Datos.instance.enemigosSpawneados < Datos.instance.nEnemigosOleada1)
        {
            //posicion donde se crea, aleatoria
            Vector3 spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

            int numEnemigo = Random.Range(0, enemies.Length);
            GameObject enemie = Instantiate(enemies[numEnemigo], spawnPosition, gameObject.transform.rotation);
            Datos.instance.enemigosSpawneados++;
            Debug.Log("Spawn");
        } 
    }

}
