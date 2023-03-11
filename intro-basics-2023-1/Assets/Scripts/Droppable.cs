using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    
    [SerializeField]
    private Lootable[] _lootsPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private Lootable CreateLoot()
    {   
        int index = Random.Range(0, 3);
        Lootable loot = Instantiate(_lootsPrefab[index]);
        return loot;
    }
    
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0){
            gameObject.SetActive(false);
            Lootable loot = CreateLoot();
	    loot.transform.position = transform.position + (Vector3)Random.insideUnitCircle*1;
        }
            
    }
}
