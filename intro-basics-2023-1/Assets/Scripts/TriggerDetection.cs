using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject gameObjectToDeactivate;
    public GameObject gameObjectToActivate;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Hit with " + col.name);
        Desaparece();
    }

    private void Desaparece()
    {
        gameObjectToDeactivate.SetActive(false);
        gameObjectToActivate.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
