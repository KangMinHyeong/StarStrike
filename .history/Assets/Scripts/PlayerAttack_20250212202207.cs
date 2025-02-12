using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject[] Lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] float TargetDist = 1000.0f;

    bool IsFire = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Fire();
        UpdateCursor();
    }

    void OnAttack(InputValue value)
    {
        IsFire = value.isPressed;
    }

    void Fire()
    {
        foreach (var Laser in Lasers)
        {
            var laserEmmision = Laser.GetComponent<ParticleSystem>().emission;
            laserEmmision.enabled = IsFire;
        }
    }

    void UpdateCursor()
    {
        crossHair.position = Input.mousePosition;
    }

}
