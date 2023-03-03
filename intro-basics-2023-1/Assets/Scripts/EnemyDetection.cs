using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour //script para detectar al player desde la zona roja
{
    [SerializeField] //mostrar campos en unity
    private GameObject _enemy;    //el enemigo es el jugador
    [SerializeField]
    private GameObject triger;
    void Start() //incializar antes de actualizar
    {

    }

    void Update() //por cada frame
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _enemy.SetActive(true); //si el enemigo (player) pasa la zona roja, se detecta y se activa
        triger.SetActive(false);
    }
}