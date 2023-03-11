using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable

{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    [SerializeField]
    private GameObject [] _LootsPrefab;
    [SerializeField]
    private float _LootProb;
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;

        HealthPoints--;
        if(HealthPoints <= 0)

            gameObject.SetActive(false);
            float r1=Random.Range(0f,1f);
            

            if(r1<=_LootProb){
                int r2=Random.Range(0,2);
                Vector2 Pos = new Vector2(transform.position.x,transform.position.y);
                Instantiate(_LootsPrefab[r2], Pos+Random.insideUnitCircle,Quaternion.identity);
            }
    }

    private void OnTriggerEnter2D(Collider2D col){
        TakeHit();
    
    }
}
