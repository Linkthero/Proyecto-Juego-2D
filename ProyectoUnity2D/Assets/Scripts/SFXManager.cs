using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public AudioSource audioSource;
    [SerializeField] private AudioClip playerDeath;
    [SerializeField] private AudioClip[] enemyHurt;
    [SerializeField] private AudioClip shot;
    [SerializeField] private AudioClip explosion;
    [SerializeField] private AudioClip pausa;
    [SerializeField] private AudioClip vida;
    [SerializeField] private AudioClip item;
    [SerializeField] private AudioClip siguienteNivel;

    public bool playedSiguienteNivel = false;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
    }


    public void PlayPlayerHurt()
    {
        if(audioSource.isPlaying) 
            return;
        audioSource.PlayOneShot(playerDeath);
    }

    public void PlayEnemigoHurt()
    {
        int n = Random.Range(0, 3);
        audioSource.PlayOneShot(enemyHurt[n]);
    }

    public void PlayDisparo()
    {
        audioSource.PlayOneShot(shot);
    }

    public void PlayExplosion()
    {
        audioSource.PlayOneShot(explosion);
    }
    public void PlayItem()
    {
        audioSource.PlayOneShot(item);
    }

    public void PlayVida()
    {
        audioSource.PlayOneShot(vida);
    }

    public void PlayPausa()
    {
        audioSource.PlayOneShot(pausa);
    }
    public void PlaySiguienteNivel()
    {
        audioSource.PlayOneShot(siguienteNivel);
    }

}
