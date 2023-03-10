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
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints=TotalHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit()
    {
        if(HealthPoints<=0){
            return ;
        }
        HealthPoints--;

        if(HealthPoints<=0){
            float random=Random.Range(0f,1f);
            gameObject.SetActive(false);
            if(random >= 0.4)
            {
                drop();
            }
        }
    }

    public void drop()
    {   
        int randomIndex = Random.Range(0, loot.Length);
        GameObject obj=Instantiate(loot[randomIndex]);
        Vector2 randompoint=Random.insideUnitCircle;
        Vector3 pos=gameObject.transform.position;
        Vector3 w=new Vector3(randompoint.x,randompoint.y,0);
        obj.transform.position=pos+w;
    }
}
