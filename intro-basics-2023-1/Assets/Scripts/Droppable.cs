using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    float randomValue;
    int randomNumber;

    public float radioCirculo = 5f;

    [SerializeField]
    public GameObject[] LootPrefabs;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
        //...
    }

    //...

    public void TakeHit()
    {
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
        {
            randomValue = Random.value;
            if (randomValue > 0.5)
            {
                randomNumber = Random.Range(0, LootPrefabs.Length);
                Debug.Log(randomNumber);
                InstanciarObjetoAleatorio(randomNumber);
            }
            gameObject.SetActive(false);
        }
    }

    void InstanciarObjetoAleatorio(int r)
    {
        Vector3 posicionActual = transform.position;
        Vector2 vectorAleatorio = Random.insideUnitCircle;
        Vector3 vectorEscalado = new Vector3(vectorAleatorio.x, 0f, vectorAleatorio.y) * radioCirculo;
        Vector3 nuevaPosicion = posicionActual + vectorEscalado;
        Instantiate(LootPrefabs[r], nuevaPosicion, Quaternion.identity);
    }

}