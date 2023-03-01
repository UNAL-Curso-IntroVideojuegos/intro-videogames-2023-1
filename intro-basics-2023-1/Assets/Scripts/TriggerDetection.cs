using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    [SerializeField]
    private TankEnemy _enemyTank;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name == "PlayerTank")
        {
            _enemyTank.changeActive();
            destroy();
        }
    }

    private void destroy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
