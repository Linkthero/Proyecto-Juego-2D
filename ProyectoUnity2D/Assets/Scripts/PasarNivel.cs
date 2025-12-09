using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour
{
    [SerializeField] private GameObject caminoSiguienteNivel;
    [SerializeField] private Fade fade;
    [SerializeField] public CapsuleCollider2D colPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        caminoSiguienteNivel.gameObject.SetActive(false);
        colPlayer = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Datos.instance.siguienteNivel)
        {
            if (!SFXManager.instance.playedSiguienteNivel)
            {
                SFXManager.instance.PlaySiguienteNivel();
                SFXManager.instance.playedSiguienteNivel = true;
            }
            caminoSiguienteNivel.gameObject.SetActive(true);
        }

        //si se pulsa 1,2,3 se carga el nivel indicado
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Datos.instance.GuardarVidas();
            Datos.instance.nivel = 1;
            StartCoroutine(fadeOutDelay());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Datos.instance.GuardarVidas();
            Datos.instance.nivel = 2;
            StartCoroutine(fadeOutDelay());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Datos.instance.GuardarVidas();
            Datos.instance.nivel = 3;
            StartCoroutine(fadeOutDelay());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SiguienteNivel"))
        {
            if(Datos.instance.enemigosMuertos == Datos.instance.nEnemigosOleada)
            {
                Datos.instance.GuardarVidas();
                Datos.instance.nivel++;
                StartCoroutine(fadeOutDelay());
            }
            
        }
    }

    public IEnumerator fadeOutDelay()
    {
        fade.gameObject.SetActive(true);
        colPlayer.enabled = false;
        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Nivel " + Datos.instance.GetNivel().ToString());
    }

    public IEnumerator fadeOutDelayNivel(string nivel)
    {
        fade.gameObject.SetActive(true);
        colPlayer.enabled = false;
        fade.FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nivel);
    }


}
