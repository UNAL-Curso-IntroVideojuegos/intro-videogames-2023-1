using UnityEngine;

public class Lootable : MonoBehaviour
{

    [SerializeField]
    private LayerMask _collisionMask;

    private Rigidbody2D _rb;

    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

      
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name== "PlayerTank"){
 		    Debug.Log("Loot grabbed by Player.");
            DestroyLootable();
 	    }
    }



       private void DestroyLootable()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}

