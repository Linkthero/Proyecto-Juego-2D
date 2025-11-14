using UnityEngine;

public class Datos : MonoBehaviour
{
    public static Datos instance;
    [SerializeField] public int maxVidas = 3;
    public int vidas;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            vidas = maxVidas;
        }
    }


    public int GetVidas()
    {
        return vidas;
    }

    public void SetVidas(int v)
    {
        vidas = v;
    }

}
