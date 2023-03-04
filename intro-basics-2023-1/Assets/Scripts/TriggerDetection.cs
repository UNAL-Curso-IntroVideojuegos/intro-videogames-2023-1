using UnityEngine;

public class TriggerDetection : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyTank;

    void OnTriggerEnter2D(Collider2D other) {
    _enemyTank.SetActive(true);
}
    void OnTriggerExit2D(Collider2D other) {
        _enemyTank.SetActive(false);
    }

}
