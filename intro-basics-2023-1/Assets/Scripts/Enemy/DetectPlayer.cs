using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private bool _enRango = false;
    [SerializeField] private EnemyTankShotter enemyTankShotter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTank")
        {
            _enRango = true;
            StartCoroutine(DispararCorrutine());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerTank")
        {
            _enRango = false;
        }
    }

    IEnumerator DispararCorrutine()
    {
        enemyTankShotter.Disparar();
        yield return new WaitForSeconds(1.5f);
        if (_enRango == true)
        {
            StartCoroutine(DispararCorrutine());
        }
    }
}
