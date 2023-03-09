
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

	[SerializeField]
    private GameObject _deadVFXPrefab;

    [SerializeField]
    private Lootable[] LootPrefabs;

    [SerializeField]
    private float LootChance = 0.5f;

    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;

        if(HealthPoints <= 0) {
            Instantiate(_deadVFXPrefab, GetComponent<Transform>().position, Quaternion.identity);

            if(Random.value <= LootChance)
            {   
                int index = Random.Range(0, LootPrefabs.Length);
                Vector3 area = Random.insideUnitCircle / 2;
                Instantiate(LootPrefabs[index], GetComponent<Transform>().position + area, Quaternion.identity);
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
