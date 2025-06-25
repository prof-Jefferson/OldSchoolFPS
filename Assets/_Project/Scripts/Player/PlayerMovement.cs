using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Velocidade de movimento")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura input (teclas W, A, S, D ou setas)
        float moveY = Input.GetAxisRaw("Horizontal"); // A/D ou ← →
        float moveX = Input.GetAxisRaw("Vertical");   // W/S ou ↑ ↓
        movement = new Vector2(moveX, (-1*(moveY))).normalized;
    }

    void FixedUpdate()
    {
        // Movimento baseado em física
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
