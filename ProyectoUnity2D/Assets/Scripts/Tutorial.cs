using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(EsperaYDesaparece());
    }

    IEnumerator EsperaYDesaparece()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
