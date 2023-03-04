using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyTank;


    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hit FROM trigger zone with " + other.collider.name);
        DestroyThis();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "PlayerTank"){
            Debug.Log("Hit FROM collision zone with " + other.name);
            DestroyThis();
        }
        
    }

    private void DestroyThis()
    {
        _enemyTank.SetActive(true);
        this.gameObject.SetActive(false);
    }
    
}
