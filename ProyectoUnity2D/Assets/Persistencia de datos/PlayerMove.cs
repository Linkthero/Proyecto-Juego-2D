using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        GameObject datosObject = GameObject.Find("Datos");
        gameManager = datosObject.GetComponent<GameManager>();
        RestaurarPosicion();
    }

    private void RestaurarPosicion()
    {
        GameDate datosLeidos = gameManager.CargarDatos();
        rb.linearVelocity = Vector2.zero;
        rb.MovePosition(new Vector3(datosLeidos.x, datosLeidos.y));
    }

    private void GuardarPosicion()
    {
        GameDate datosAGuardar = new GameDate();
        datosAGuardar.x = rb.position.x;
        datosAGuardar.y = rb.position.y;
        gameManager.SaveGame(datosAGuardar);
    }

    private void OnDestroy()
    {
        GuardarPosicion();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * speed ;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
