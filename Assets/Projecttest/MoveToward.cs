using UnityEngine;
using UnityEngine.InputSystem;

public class MoveToward : MonoBehaviour
{
    [SerializeField] Transform objectToMove;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 3f;

    InputAction moveAction;

    bool moveToB = true;

    void Awake()
    {
        moveAction = InputSystem.actions.FindAction("MoveAction");
    }

    void Update()
    {
        if (moveAction.WasPressedThisFrame())
        {
            moveToB = !moveToB;
        }

        Vector2 target;

        if (moveToB)
        {
            target = pointB.position;
        }
        else
        {
            target = pointA.position;
        }

        objectToMove.position = Vector2.MoveTowards(
            objectToMove.position,
            target,
            speed * Time.deltaTime
        );
    }
}