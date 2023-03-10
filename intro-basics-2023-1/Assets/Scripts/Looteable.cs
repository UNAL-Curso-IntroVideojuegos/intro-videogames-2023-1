using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Looteable : MonoBehaviour
{

    [SerializeField]
    private bool _disableOnDetection;

    public UnityEvent OnDetection;

    void Update()
    {
        transform.Rotate(Vector3.forward, 16 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnDetection?.Invoke();
            if (_disableOnDetection)
            {
                gameObject.SetActive(false);
                UnityEngine.Debug.Log("Loot grabbed by Player");
            }
        }
    }
}