using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;
    private Vector2 lastMoveDirection;
    private bool facingLeft = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveInput.x > 0 && !facingLeft || moveInput.x > 0 && facingLeft)
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * velocidad;
    }

    public void OnMove(InputValue inputvalue) 
    {

        moveInput = inputvalue.Get<Vector2>();
        //animator.SetFloat("x", inputvalue.Get<Vector2>().x);
        //animator.SetFloat("y", inputvalue.Get<Vector2>().y);
    }

    void ProccessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if((moveX == 0 && moveY == 0) && (moveInput.x != 0 || moveInput.y != 0))
        {
            lastMoveDirection = moveInput;
        }
    }

    void Animate()
    {
        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);
        animator.SetFloat("MoveMagnitude", moveInput.magnitude);
        animator.SetFloat("LastMoveX", lastMoveDirection.x);
        animator.SetFloat("LastMoveY", lastMoveDirection.y);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingLeft = !facingLeft;
    }
}
