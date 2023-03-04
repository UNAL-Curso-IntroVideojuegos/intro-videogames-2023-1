using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TankEnemy.sharedInstace.SetIsStactic(false);
            Destroy(gameObject);

        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
