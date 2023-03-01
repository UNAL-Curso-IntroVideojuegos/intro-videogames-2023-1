using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    public GameObject gameObjectToDeactivate;
    [SerializeField]
    public GameObject gameObjectToActivate;
    //[SerializeField]
    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col){
	    Debug.Log("Hit with " + col.name);
        MostrarObjeto();
    }
    // Update is called once per frame
    private void MostrarObjeto(){
        gameObjectToDeactivate.SetActive(false);
        gameObjectToActivate.SetActive(true);

    }
    void Update()
    {
        
    }
    
}