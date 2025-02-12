using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject[] Lasers;
    [SerializeField] RectTransform crossHair;
    [SerializeField] float TargetDist = 1000.0f;

    bool IsFire = false;
    Vector3 TargetPoint;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Fire();
        UpdateTargetLocation();
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

    void UpdateTargetLocation()
    {
        crossHair.position = Input.mousePosition;

        Vector3 Pos = new Vector3(crossHair.position.x, crossHair.position.y, TargetDist);
        TargetPoint = Camera.main.ScreenToWorldPoint(Pos);
    }

    void AimToTarget()
    {
        foreach (var Laser in Lasers)
        {
            var TargetVec = TargetPoint - Laser.transform.position;
            Laser.transform.rotation = Quaternion.LookRotation(TargetVec);
        }
    }
}
