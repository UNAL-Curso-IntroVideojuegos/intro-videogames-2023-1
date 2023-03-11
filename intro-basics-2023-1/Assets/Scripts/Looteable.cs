using UnityEngine;

public class Looteable : MonoBehaviour {

    [SerializeField] private float _speed;

    

    // Update is called once per frame
    void Update() {

        Rotation();
    }

    void Rotation() {
        
        transform.Rotate(Vector3.forward, _speed * Time.deltaTime);
    
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log("Loot grabbed by Player");
            }
    }

    }


