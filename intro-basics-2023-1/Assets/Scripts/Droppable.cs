using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Droppable : MonoBehaviour, IDamageable
{
    [SerializeField]
    private Transform[] Loots;
    private float randomValue;
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
            randomValue=Random.value; 
            if(randomValue>0.5)
            {
                posLoot = Random.Range(0, Loots.Length);
                MostrarLoot(posLoot);
            } 
            gameObject.SetActive(false);
        }
    }
    void MostrarLoot(int pos)
    {
        Vector3 LootPos = Random.insideUnitCircle *3;
        LootPos+=transform.position;
        Instantiate(Loots[pos],LootPos,Quaternion.identity);
    }
}