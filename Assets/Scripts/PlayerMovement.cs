using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float controlSpeed = 10f;
    [SerializeField] private float xClampRange = 5f;
    [SerializeField] private float yClampedRange = 5f;

    private Vector2 movement;

    private void Update()
    {
        ProcessTranslation();
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
}