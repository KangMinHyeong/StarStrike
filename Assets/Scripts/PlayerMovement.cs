using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    [SerializeField] float Max_xOffset = 32.0f;
    [SerializeField] float Max_yOffset = 18.0f;

    [SerializeField] float RotationFactor_X = 20.0f;
    [SerializeField] float RotationFactor_Y = 50.0f;
    [SerializeField] float RotationSpeed = 5.0f;

    
    Vector2 MoveValue;

    void Update()
    {
        PlayerMove();
        PlayerRotation();
    }

    private void PlayerMove()
    {
        float xOffset = Time.deltaTime * MoveSpeed * MoveValue.x;
        float Final_xOffset = Mathf.Clamp(transform.localPosition.x + xOffset, -Max_xOffset, Max_xOffset);

        float yOffset = Time.deltaTime * MoveSpeed * MoveValue.y;
        float Final_yOffset = Mathf.Clamp(transform.localPosition.y + yOffset, -Max_yOffset, Max_yOffset);

        transform.localPosition = new Vector3(Final_xOffset, Final_yOffset, 0.0f);
    }

    private void PlayerRotation()
    {
        Quaternion Rot = Quaternion.Euler(-RotationFactor_Y * MoveValue.y, 0.0f, -RotationFactor_X * MoveValue.x);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Rot, RotationSpeed * Time.deltaTime);
    }

    void OnMove(InputValue value)
    {
        MoveValue = value.Get<Vector2>();
    }
}
