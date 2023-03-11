using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Looteable : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float _localRotationSpeed; // degrees/sec

    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        if (_rb != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
            UnityEngine.Debug.Log("Loot grabbed by Player");
        }
    }
}
