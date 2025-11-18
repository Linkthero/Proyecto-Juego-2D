using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    [SerializeField] private GameObject caminoSiguienteNivel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        caminoSiguienteNivel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {        
        if(Datos.instance.siguienteNivel)
        {
            caminoSiguienteNivel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SiguienteNivel"))
        {
            SceneManager.LoadScene("Nivel " + Datos.instance.GetNivel().ToString());
        }
    }


}
