using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField]
    private GameObject[] _lootableObjects;
    
    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }
    
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0){
            aparecerLootable();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    public void aparecerLootable()
    {
        Vector3 distaciaDroppable = Random.insideUnitCircle *4;
        int lootableObjectId = Random.Range(0, _lootableObjects.Length);
        GameObject lootable = Instantiate(_lootableObjects[lootableObjectId]);
        lootable.transform.position = transform.position + distaciaDroppable;
        lootable.transform.rotation = transform.rotation;

    }

    
}
