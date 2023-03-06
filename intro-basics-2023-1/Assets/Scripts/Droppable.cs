using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    public GameObject[] objectsToDrop; // array of objects to drop
    public float dropProbability; // probability of dropping an object
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0)
            gameObject.SetActive(false);
            DropObject();
    }
    void DropObject()
{
    if (Random.Range(0f, 1f) <= dropProbability)
    {
        int randomIndex = Random.Range(0, objectsToDrop.Length);
        GameObject droppedObject = Instantiate(objectsToDrop[randomIndex], transform.position, Quaternion.identity);
    }
    
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
}
