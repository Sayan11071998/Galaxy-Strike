using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject destroyedVFX;

    private GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}