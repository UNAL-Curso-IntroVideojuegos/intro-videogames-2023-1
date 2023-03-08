using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Droppable : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Transform[] Loots;

   
    private float randyValue;
    
    
    private int posLoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    [field:SerializeField]
    public int TotalHealthPoints { get; set; }
    public int HealthPoints { get; set; }
    
    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
        {
            return; 
        }
        HealthPoints--;
        if(HealthPoints <= 0){
            randyValue=Random.value; 
            if(randyValue>0.3){
                posLoot=Random.Range(0,Loots.Length); 
                Debug.Log(posLoot);
                MostrarLoot(posLoot);
            } 
            gameObject.SetActive(false);
        }
    }
    void MostrarLoot(int pos)
    {
        Vector3 LootPos = Random.insideUnitCircle *2;
        LootPos+=transform.position;
        Instantiate(Loots[pos],LootPos,Quaternion.identity);
    }
}
