using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampedRange = 5f;

    [SerializeField] private float controlPitchFactor = 18f;
    [SerializeField] private float controlRollFactor = 20f;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue vaue)
    {
        movement = vaue.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampedRange, yClampedRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    private void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}