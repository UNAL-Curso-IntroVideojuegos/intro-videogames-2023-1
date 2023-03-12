using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }
    [SerializeField]
    public GameObject[] LootPrefabs;
    [SerializeField]
    private float _lootRange = 0.5f;
    int randomObject;
    public float radCircle = 5f;
    private Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
    }
    public void TakeHit()
    {
        HealthPoints--;
        if (HealthPoints <= 0)
        {
            if (Random.value > _lootRange)
            {
                randomObject = Random.Range(0, LootPrefabs.Length);
                RandomObject(randomObject);
            }
            gameObject.SetActive(false);
        }
    }
    void RandomObject(int r)
    {
        Vector2 Aleatorio = Random.insideUnitCircle;
        Vector3 Actual = transform.position;
        Vector3 Escalado = new Vector3(Aleatorio.x, 0f, Aleatorio.y) * radCircle;
        Vector3 newPosicion = Actual + Escalado;
        Instantiate(LootPrefabs[r], newPosicion, Quaternion.identity);
    }
}
