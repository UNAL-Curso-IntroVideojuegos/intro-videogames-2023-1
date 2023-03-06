using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints {get; private set;}
    public int HealthPoints {get; private set;}

    [SerializeField]
    private GameObject[] loot;
    
    void Start()
    {
        
        HealthPoints=TotalHealthPoints;
        
    }



    public void TakeHit(){

        if(HealthPoints<=0){
            return ;}

        HealthPoints--;

        if(HealthPoints<=0){

            float random=Random.Range(0f,1f);

            Vector2 randompoint=Random.insideUnitCircle;

            Vector3 pos=gameObject.transform.position;
            gameObject.SetActive(false);

            if(random >=0.3){
                GameObject obj=Instantiate(loot[Random.Range(0,loot.Length)]);
                Vector3 w=new Vector3(randompoint.x,randompoint.y,0);
                obj.transform.position=pos+w;


            }

            
        }
    }
    void Update()
    {
    
    }
}
