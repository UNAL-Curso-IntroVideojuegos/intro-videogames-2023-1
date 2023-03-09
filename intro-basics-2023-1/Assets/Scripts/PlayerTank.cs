using UnityEngine;

public class PlayerTank : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

	[SerializeField]
    private GameObject _deadVFXPrefab;
    
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
            gameObject.SetActive(false);
        }
    }
}
