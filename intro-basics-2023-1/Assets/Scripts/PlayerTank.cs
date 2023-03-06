using UnityEngine;

public class PlayerTank : MonoBehaviour, IDamageable
{
    [field:SerializeField]
    
    public int TotalHealthPoints { get; private set; }
    
    public int HealthPoints { get; private set; }
    
    private void Start()
    {
        HealthPoints = TotalHealthPoints;
    }
    
    public void TakeHit()
    {
        if(HealthPoints <= 0)
            return;
    
        HealthPoints--;
        if(HealthPoints <= 0)
            gameObject.SetActive(false);
    }
}
