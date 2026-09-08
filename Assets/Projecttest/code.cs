using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    InputAction MoveAction;
    InputAction JumpAction;
    InputAction AttackAction;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 10f;

    Vector2 movement;

    // Kiểm tra Player có đang chạm đất không
    bool isGrounded = false;

    // Số lượng Coin
    int coinCount = 0;

    void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("MoveTopDown");
        JumpAction = InputSystem.actions.FindAction("Jump");
        AttackAction = InputSystem.actions.FindAction("Attack");

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Di chuyển
        movement = MoveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(
            movement.x * speed,
            rb.linearVelocity.y
        );


        // NHẢY
        if (JumpAction.WasPerformedThisFrame() && isGrounded)
        {
            rb.linearVelocityY = jump;
        }


        // TẤN CÔNG
        if (AttackAction.WasPerformedThisFrame())
        {
            Debug.Log("Attack");
        }
    }


    // KIỂM TRA CHẠM ĐẤT
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    // NHẶT COIN
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;

            Debug.Log("Coin: " + coinCount);

            Destroy(other.gameObject);
        }
    }
}

