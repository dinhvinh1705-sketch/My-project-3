using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    
    InputAction MoveAction;
    InputAction JumpAction;

    InputAction ShootAction;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 10f;

    [SerializeField] float knockbackForce = 5f;
    public UnityEvent OnShoot;
    Vector2 movement;

    bool IsGround = false;

    void Awake()
    {
        MoveAction = InputSystem.actions.FindAction("MoveTopDown");
        JumpAction = InputSystem.actions.FindAction("Jump");
        ShootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        movement = MoveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(movement.x * speed, rb.linearVelocity.y);

        if(JumpAction.WasPerformedThisFrame() && IsGround)
        {
            rb.linearVelocityY = jump;
        }

        if(ShootAction.WasPerformedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Debug.Log("Player bắn");

        OnShoot.Invoke();

        rb.AddForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsGround = false;
        }
    }
}