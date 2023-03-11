using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{
    private Transform loot;

    // Start is called before the first frame update
    void Start()
    {
        loot = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        loot.rotation = Quaternion.Euler(0, 0, Time.time * Mathf.Rad2Deg); ;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Loot grabbed by Player");
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
