using System.Collections;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    //array de enemigos
    public GameObject[] enemies;

    //tiempo q pasa para spawnear
    public float timeSpawn = 1;

    //se crea un enemigo cada 3s
    public float repeatSpawnRate = 3;

    [SerializeField] private int numEnemigosOleada;
    private int numEnemigosSpawn;

    //bordes, areas q delimitan

    [SerializeField] public Transform xRangeLeft;
    [SerializeField] public Transform xRangeRight;

    [SerializeField]  public Transform yRangeUp;
    [SerializeField]  public Transform yRangeDown;


    void Start()
    {
        //StartCoroutine(Example());
        InvokeRepeating("SpawnEnemies", timeSpawn, repeatSpawnRate);
    }

    public void SpawnEnemies()
    {
        if (numEnemigosSpawn < numEnemigosOleada)
        {
            //posicion donde se crea, aleatoria
            Vector3 spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

            int numEnemigo = Random.Range(0, enemies.Length);
            GameObject enemie = Instantiate(enemies[numEnemigo], spawnPosition, gameObject.transform.rotation);
            numEnemigosSpawn++;
        }        
    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
    }

}
