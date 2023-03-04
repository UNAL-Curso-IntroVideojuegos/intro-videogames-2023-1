using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    private float tankDirection = 1;

    [SerializeField] private Transform barrel1;

    [SerializeField] private Transform barrel2;

    public Transform[] barrels = new Transform[2];

    private Transform playerTank;
    
    
    // Start is called before the first frame update
    void Start()
    {   gameObject.SetActive(false);
        playerTank = FindObjectOfType<PlayerTankMovement>().transform;
        barrels[0] = barrel1;
        barrels[1] = barrel2;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Initial Moving of the enemy tank
        transform.Translate(Vector3.right * Time.deltaTime * tankDirection);
        
        //Handle barrels
        Vector2 direction =  playerTank.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        foreach (Transform barrel in barrels)
        {
            barrel.rotation = Quaternion.Euler(0,0,angle);
        }

    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("topBound"))
        {
            tankDirection = -1;
        }

        if (collision.CompareTag("bottomBound"))
        {
            tankDirection = 1;
        }
    }
}
