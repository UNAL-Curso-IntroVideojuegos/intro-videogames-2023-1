using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyTank;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("CollisionDetected");
        gameObject.SetActive(false);
        enemyTank.SetActive(true);
        Destroy(gameObject);
    }
}
