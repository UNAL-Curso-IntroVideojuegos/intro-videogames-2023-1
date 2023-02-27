using UnityEngine;

public class TriggerDetection : MonoBehaviour {

    [SerializeField]
    private GameObject _Enemy;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Enemy activated for " + other.name);
        _Enemy.SetActive(true);
        gameObject.SetActive(false);
    }
}
