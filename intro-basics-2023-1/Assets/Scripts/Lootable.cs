using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{   
	[SerializeField]
    private float rotationSpeed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
    }

	private void OnTriggerEnter2D(Collider2D player){
        Destroy(gameObject);
        Debug.Log("Loot grabbed by Player ✨");
    }
}
