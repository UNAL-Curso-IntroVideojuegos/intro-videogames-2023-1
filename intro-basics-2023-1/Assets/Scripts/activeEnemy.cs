using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeEnemy : MonoBehaviour
{
    public GameObject objectToActivate; // Referencia al objeto que se activará



    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
            objectToActivate.SetActive(true); // Activa el objeto cuando el jugador entra en la zona de colisión
        
    }
}
