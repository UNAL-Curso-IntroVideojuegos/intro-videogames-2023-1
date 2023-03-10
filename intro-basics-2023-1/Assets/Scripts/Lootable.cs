using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootable : MonoBehaviour
{   

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "PlayerTank"){
            gameObject.SetActive(false);
            Destroy(gameObject);
            Debug.Log(" Loot grabbed by Player");
        }
    }
}
