using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{   [SerializeField]
    private float rotationSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D player){
        if(player.CompareTag("Player")){
        Destroy(gameObject);
        Debug.Log("Loot grabbed by Player");}
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
