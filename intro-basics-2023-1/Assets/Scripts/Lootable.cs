using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lootable : MonoBehaviour
{
    [SerializeField]
    private bool _disableOnDetection;
    public UnityEvent OnDetection;
    [Header("Rotation")]
    [SerializeField] private float _localRotationSpeed; // degrees/sec

 

    void Update()
    {
        IndependentRotation();



    }




    void IndependentRotation()
    {
        transform.Rotate(Vector3.forward, _localRotationSpeed * Time.deltaTime);
    }









    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnDetection?.Invoke();
            Debug.Log("Loot grabbed by Player ");
            if (_disableOnDetection)
                gameObject.SetActive(false);
        }
    }
}
