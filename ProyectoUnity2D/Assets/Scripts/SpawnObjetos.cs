using System.Collections;
using UnityEngine;

public class SpawnObjetos : MonoBehaviour
{
    //array de enemigos
    public GameObject[] items;

    //tiempo q pasa para spawnear
    public float timeSpawn = 5;

    //se crea un enemigo cada x seg
    public float repeatSpawnRate;


    //bordes, areas q delimitan

    [SerializeField] public Transform xRangeLeft;
    [SerializeField] public Transform xRangeRight;

    [SerializeField]  public Transform yRangeUp;
    [SerializeField]  public Transform yRangeDown;


    void Start()
    {
        repeatSpawnRate = (float)Random.Range(10, 15);
        //StartCoroutine(Example());
        InvokeRepeating("Spawn", timeSpawn, repeatSpawnRate);
    }

    public void Spawn()
    {
        //posicion donde se crea, aleatoria
        Vector3 spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);

        int nItem = Random.Range(0, items.Length);
        Instantiate(items[nItem], spawnPosition, gameObject.transform.rotation);        
    }

}
