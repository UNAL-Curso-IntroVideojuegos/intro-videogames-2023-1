using UnityEngine;
using UnityEngine.Events;

public class Lootable : MonoBehaviour
{
    [SerializeField] private bool _disableOnDetection;
    public UnityEvent OnDetection;
    [SerializeField] private float _rotationSpeed = 1f;

    private void Start()
    {
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnDetection?.Invoke();
            if (_disableOnDetection)
            {
                gameObject.SetActive(false);
            }
            Debug.Log("Loot grabbed by player");
        }
    }
}

