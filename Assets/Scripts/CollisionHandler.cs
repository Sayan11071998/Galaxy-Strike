using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}