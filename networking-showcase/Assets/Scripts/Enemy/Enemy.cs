using UnityEngine;

namespace AllieJoe.Gameplay
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        [field: SerializeField] public int TotalHealthPoints { get; private set; } = 10;
        [field: SerializeField] public int HealthPoints { get; private set; }

        private void Start()
        {
            HealthPoints = TotalHealthPoints;
        }

        public void TakeHit(int damage, Vector3 position)
        {
            if (HealthPoints <= 0)
                return;

            HealthPoints -= damage;
            if (HealthPoints <= 0)
            {
                HealthPoints = 0;
                Death();
            }
        }

        private void Death()
        {
            gameObject.SetActive(false);
        }

        private void OnValidate()
        {
            HealthPoints = TotalHealthPoints;
        }
    }
}