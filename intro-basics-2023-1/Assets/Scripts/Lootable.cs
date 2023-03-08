using UnityEngine;

public class Lootable : MonoBehaviour
{
    [SerializeField] private float _localRotationSpeed = 30f; // degrees/sec
    
    private void Update()
    {
        // Rotate self
        transform.Rotate(Vector3.forward, _localRotationSpeed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Loot grabbed by " + other.name);
        DestroyLoot();
    }
    
    private void DestroyLoot()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
