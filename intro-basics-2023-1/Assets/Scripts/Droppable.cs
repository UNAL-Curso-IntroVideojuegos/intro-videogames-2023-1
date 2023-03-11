using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{

    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    [SerializeField]
    private GameObject [] _Loots;
    [SerializeField]
    private float _LootChance;
    private float _indice;
    private int _indice1;

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
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0){
            gameObject.SetActive(false);
            _indice=Random.Range(0f,1f);
            _indice1=Random.Range(0,2);
            Vector2 objPos=new Vector2(transform.position.x,transform.position.y);

            if(_indice<=_LootChance){
                Instantiate(_Loots[_indice1],objPos+Random.insideUnitCircle*2,Quaternion.identity);
            }
    }
    
    }
}
