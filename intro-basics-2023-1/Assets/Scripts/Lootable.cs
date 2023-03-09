
using UnityEngine;

public class Lootable : MonoBehaviour
{   
    private Transform _tf;

    private void Start()
    {   
        _tf = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _tf.rotation = Quaternion.Euler(0, 0, Time.time * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Loot grabbed by Player");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
