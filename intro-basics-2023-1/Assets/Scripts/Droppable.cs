using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{   
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private Transform[] _LootPrefabs;

    [SerializeField]
    private float _LootChance;

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
        {
            gameObject.SetActive(false);
            GenerateLoot();
        }
            

    }

    private void GenerateLoot()
    {
        float prop = Random.value; //Generar numero aleatrorio, si es menor al loot chance se genera

        if (prop < _LootChance)
        {
             //Seleccionar loot
            int index = Random.Range(0, _LootPrefabs.Length);
            Transform loot = _LootPrefabs[index];

            Vector2 posicion = Random.insideUnitCircle;
            float posicionx = posicion[0] + transform.position.x;
            float posiciony = posicion[1] + transform.position.y;

            Vector2 n_pos = new Vector2(posicionx, posiciony);

            Instantiate(loot, n_pos, Quaternion.identity);

            //Debug.Log("Genera loot");
        }
       
    }
}
