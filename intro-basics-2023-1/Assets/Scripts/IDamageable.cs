

using UnityEngine;

public interface IDamageable
{
    public int TotalHealthPoints { get; }
    public int HealthPoints { get; }
    
    public void TakeHit();
}

// public class Tank : MonoBehaviour, IDamageable
// {
//     [field:SerializeField]
//     public int TotalHealthPoints { get; private set; }
//     public int HealthPoints { get; private set; }
//     
//     protected virtual void Start()
//     {
//         HealthPoints = TotalHealthPoints;
//     }
//
//     public void TakeHit()
//     {
//         if(HealthPoints <= 0)
//             return;
//
//         HealthPoints--;
//         if(HealthPoints <= 0)
//             gameObject.SetActive(false);
//     }
// }