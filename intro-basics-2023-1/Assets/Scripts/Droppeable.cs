using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppeable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    public GameObject[] objectsToDrop; // array of objects to drop
    public float dropProbability; // probability of dropping an object
    public float radio = 5f;

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
        if(HealthPoints <= 0){
            if(Random.value < dropProbability){
                DropObject();
            }
            gameObject.SetActive(false);
        }
    }
    void DropObject()
{

        int randomIndex = Random.Range(0, objectsToDrop.Length);
        Vector2 circulo = Random.insideUnitCircle;
        Vector3 conversion = new Vector3(circulo.x, 0f, circulo.y);
        conversion = conversion*radio;
        Vector3 nuevo = transform.position + conversion;
        Instantiate(objectsToDrop[randomIndex], nuevo, Quaternion.identity);

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
}
