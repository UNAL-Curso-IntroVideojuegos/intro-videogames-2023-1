using UnityEngine;

public class Droppable : MonoBehaviour, IDamageable
{   
    [field:SerializeField]
    public int TotalHealthPoints {get; private set;}
    public int HealthPoints {get; private set;}

    [SerializeField]
    private GameObject[] lootsObject;


    [SerializeField]
    private float _probability;
    
    void Start()
    {
        HealthPoints=TotalHealthPoints;
    }

    public void TakeHit()
    {
        if(HealthPoints<=0){
            return ;
        }
        HealthPoints--;

        if(HealthPoints<=0){
            gameObject.SetActive(false);
            float random = Random.Range(0f,1f);
            if(random <= _probability) {
                createLoot();
            }
        }
    }

    private void createLoot()
    {   
        int indexLoot = Random.Range(0, lootsObject.Length);
        GameObject obj=Instantiate(lootsObject[indexLoot]);
        Vector2 randomPosition = Random.insideUnitCircle * 2;
        obj.transform.position = transform.position + new Vector3(randomPosition.x, randomPosition.y, 1) ;

    }
}