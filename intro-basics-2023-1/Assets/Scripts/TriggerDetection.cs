using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemy;


    private Rigidbody2D _rb;

    void Start()
    {
    _rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D col)
		{
		    _enemy.gameObject.SetActive(true);
            DestroyProjectile();
        }

        private void DestroyProjectile()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

}