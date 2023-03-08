using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour, IDamageable{

     [SerializeField]
     List<GameObject> lootables = new List<GameObject>();
     [SerializeField]
     [Range(0,1)]
     private float lootChance;

     [field:SerializeField]
     public int TotalHealthPoints { get; private set; }
     public int HealthPoints { get; private set; }

    // Start is called before the first frame update
    void Start(){
          HealthPoints = TotalHealthPoints;
    }

    // Update is called once per frame
    void Update(){
        
    }

     public void TakeHit(){
          if(HealthPoints <= 0){
               return;
          }
            
          HealthPoints--;
          if(HealthPoints <= 0){
               float randomNumber1 = Random.Range(0f, 1f);

               if (randomNumber1 < lootChance){
                    float randomNumber2 = Random.Range(0f, 2f);
                    if (randomNumber2 < 1f){
                         Vector2 initPosition = new Vector2(transform.position.x , transform.position.y);
                         GameObject lootable = Instantiate(lootables[0]);
                         lootable.transform.position = initPosition + Random.insideUnitCircle * 2f;

                    }else{
                         Vector2 initPosition = new Vector2(transform.position.x , transform.position.y);
                         GameObject lootable = Instantiate(lootables[1]);
                         lootable.transform.position = initPosition + Random.insideUnitCircle * 2f;
                    }
               }else{
                    print ("no loot :(");
               }
               DestroyLootable();
          }
     }

    private void DestroyLootable(){
          gameObject.SetActive(false);
          Destroy(gameObject);
     }
}
