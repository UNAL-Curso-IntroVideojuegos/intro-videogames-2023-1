using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField] private GameObject barrera;
    [SerializeField] private GameObject enemigo;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        barrera.SetActive(false);
        enemigo.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
