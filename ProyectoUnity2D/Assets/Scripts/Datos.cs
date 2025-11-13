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
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidas = maxVidas;
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void SetVidas(int v)
    {
        vidas = v;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
