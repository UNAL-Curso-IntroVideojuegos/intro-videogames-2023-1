using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] private float _localRotationSpeed = 40;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, _localRotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerTank")
        {
            Debug.Log("Loot grabbed by Player");
            gameObject.SetActive(false);
            Object.Destroy(gameObject);
        }
    }
}
