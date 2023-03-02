using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    [SerializeField] private Transform _startMovPoint;
    [SerializeField] private Transform _endMovPoint;
    private int current = 0;
    private float speed = 1;
    private Rigidbody2D _rb;
    private float _rotAngle;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (current == 0)
        {
            float distancia = Vector3.Distance(transform.position, _endMovPoint.position);
            if (distancia < 1f)
            {
                current = 1;
            }
            Vector3 direccion = (transform.position - _endMovPoint.position).normalized;
            float velocidad = speed * Time.deltaTime;
            _rb.velocity = transform.up * speed * -direccion.magnitude;
        }
        else {
            
            float distancia = Vector3.Distance(transform.position, _startMovPoint.position);
            if (distancia < 1f)
            {
                current = 0;
                //_rotAngle = Mathf.Atan2(_startMovPoint.position.x, _startMovPoint.position.) * Mathf.Rad2Deg - 90;
            }
            else
            {
                Vector3 direccion = (transform.position - _startMovPoint.position).normalized;
                float velocidad = speed * Time.deltaTime;
                _rb.velocity = transform.up * speed * direccion.magnitude;
            }
        }
        
    }
}
