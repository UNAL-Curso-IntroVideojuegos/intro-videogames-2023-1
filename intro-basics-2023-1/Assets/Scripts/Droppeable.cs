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
    public float radio = 0.5f;
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
            if(Random.value>dropProbability){
                DropObject();
        }
            gameObject.SetActive(false);
    }
    void DropObject()
{
        Vector2 posicion = Random.insideUnitCircle;
        Vector3 lugar = new Vector3(posicion.x, 0f, posicion.y) * radio;
        int randomIndex = Random.Range(0, objectsToDrop.Length);
        Instantiate(objectsToDrop[randomIndex], lugar + transform.position, Quaternion.identity);
    
    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
}
}
