using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    public interface IDamageable
    {
        public int TotalHealthPoints { get; }
        public int HealthPoints { get; }
    
        public void TakeHit(int damage, Vector3 position);
    }
}