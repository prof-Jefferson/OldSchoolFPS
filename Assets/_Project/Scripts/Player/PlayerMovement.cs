using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidade de movimento")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;
    private Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura do input do jogador
        float vertical = (-1*(Input.GetAxisRaw("Horizontal")));     // A/D
        float horizontal = Input.GetAxisRaw("Vertical");            // W/S
        input = new Vector2(horizontal, vertical).normalized;

        // Calcula a direção com base na rotação atual do player
        Vector2 forward = transform.up;
        Vector2 right = transform.right;

        // Move na direção rotacionada
        moveDirection = (right * input.x + forward * input.y).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
