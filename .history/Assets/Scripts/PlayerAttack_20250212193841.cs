using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject Laser;

    bool IsFire = false;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void OnAttack(InputValue value)
    {
        IsFire = value.isPressed;
    }

    void Fire()
    {
        var laserEmmision = Laser.GetComponent<ParticleSystem>().emission;
        laserEmmision.enabled = IsFire;
    }

}
