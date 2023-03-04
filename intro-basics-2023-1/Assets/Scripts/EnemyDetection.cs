using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{    
    [SerializeField]
    private GameObject _enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
