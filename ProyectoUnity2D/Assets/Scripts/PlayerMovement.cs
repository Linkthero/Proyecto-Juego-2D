using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;


    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private const string lastHorizontal = "LastHorizontal";
    private const string lastVertical = "LastVertical";

    public bool mirandoDerecha = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        rb.linearVelocity = movement * moveSpeed;

        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);

        if(movement != Vector2.zero)
        {
            animator.SetFloat(lastHorizontal, movement.x);
            animator.SetFloat(lastVertical, movement.y);
        }

        if (movement.x > 0 && !mirandoDerecha)
        {
            mirandoDerecha = true;
        }
        else if (movement.x < 0 && mirandoDerecha)
        {
            mirandoDerecha = false;
        }
    }

    public void Parar()
    {
        moveSpeed = 0;
        GameObject[] arrayEnemigos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in arrayEnemigos)
        {
            item.GetComponent<Enemy>().speed = 0;
        }
        //movement = Vector2.zero;
        //rb = null;
    }
}
