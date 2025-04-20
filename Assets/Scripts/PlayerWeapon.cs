using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject laser;

    private bool isFiring = false;

    private void Update()
    {
        ProcessFiring();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }
}