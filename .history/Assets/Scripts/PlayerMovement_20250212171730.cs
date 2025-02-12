using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    Vector2 MoveValue;

    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float xOffset = Time.deltaTime * MoveSpeed * MoveValue.x;
        float yOffset = Time.deltaTime * MoveSpeed * MoveValue.y;

        transform.localPosition += new Vector3(xOffset, yOffset, 0.0f);
    }

    void OnMove(InputValue value)
    {
        MoveValue = value.Get<Vector2>();
    }
}
