using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    [SerializeField]
    private float _lootChance;
    [SerializeField]
    private GameObject[] _lootPrefabs;
    
    private float _probability;
    public int HealthPoints { get; private set; }
    void Start()
    {
        HealthPoints = TotalHealthPoints;
        _probability = Random.Range(0f,1f);
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
            if (_probability>_lootChance) {
                int element= Random.Range(0,_lootPrefabs.Length);
                Vector2 randomPos = Random.insideUnitCircle;
                GameObject lootObject = Instantiate(_lootPrefabs[element],(Vector2)transform.position+randomPos,Quaternion.identity);

            }
        }
    }
}
