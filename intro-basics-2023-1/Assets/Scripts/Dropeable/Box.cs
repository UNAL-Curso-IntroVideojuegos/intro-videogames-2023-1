using UnityEngine;

public class Box : MonoBehaviour, IDamageable
{
    [SerializeField] private float _lootChance;
    [SerializeField] private GameObject[] _lootPrefabs;
    [field: SerializeField] public int TotalHealthPoints { get; private set; }

    public int HealthPoints { get; private set; }

    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }

    public void TakeHit()
    {
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
        {
            DropearObjetos();
            gameObject.SetActive(false);
        }
    }

    private void DropearObjetos()
    {
        float probabilidad = Random.Range(0f, 1f);
        Debug.Log("Probabilidad: " + probabilidad);

        if (probabilidad <= _lootChance)
        {
            int randomItem = Random.Range(0, 2);
            Debug.Log("Objeto: " + randomItem);
            GameObject newDrop = Instantiate(_lootPrefabs[randomItem]);
            Vector3 randomDesviation = Random.insideUnitCircle;
            newDrop.transform.position = transform.position + randomDesviation;
        }
    }
}
