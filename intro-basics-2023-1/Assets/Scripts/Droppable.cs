using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    // Start is called before the first frame update
    private float _randomNumber;
    [SerializeField]
    private GameObject[] _Loot;
    [SerializeField]
    private float probabilityLoot = 0.8f;
    void Start()
    {
        HealthPoints = TotalHealthPoints;
        _randomNumber = Random.value;
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
            Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log(_randomNumber);
        if (_randomNumber < probabilityLoot)
        {
            int index = Random.Range(0/*int*/, 2/*int*/);
            Debug.Log(index);
            try
            {
                GameObject loot = Instantiate(_Loot[index]);
                Vector3 unitCircle = Random.insideUnitCircle;
                Vector3 position = this.transform.position;
                loot.transform.position = position + unitCircle;
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
