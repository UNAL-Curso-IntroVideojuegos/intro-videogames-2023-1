using UnityEngine.Events;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 0.5f;
    public UnityEvent OnDetection;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    void DestroyCollectable() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            DestroyCollectable();
            Debug.Log("Loot grabbed by Player.");
;        }
    }
}