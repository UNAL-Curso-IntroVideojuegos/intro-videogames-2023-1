using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBullet : MonoBehaviour
{
    [SerializeField]
    private float _speed = 7;
    
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DestroyProjectile()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }  
}
