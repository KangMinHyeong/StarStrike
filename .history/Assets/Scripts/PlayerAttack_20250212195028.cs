using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject[] Lasers;

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
        foreach (var Laser in Lasers)
        {
            var laserEmmision = Laser.GetComponent<ParticleSystem>().emission;
            laserEmmision.enabled = IsFire;
        }
    }

}
