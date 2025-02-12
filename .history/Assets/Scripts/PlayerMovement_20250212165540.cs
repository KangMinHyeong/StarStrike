using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        Debug.Log(value.Get<Vector2>());
    }
}
