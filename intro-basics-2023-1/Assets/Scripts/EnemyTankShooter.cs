using UnityEngine;

public class EnemyTankShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private Transform[] shootPoint;

    public float timeRemaining = 10;
    public float timeRemaining1 = 10;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0)
            {
                foreach (Transform i in shootPoint)
                {
                    GameObject projectile = Instantiate(projectilePrefab);
                    projectile.transform.position = i.position;
                    projectile.transform.rotation = i.rotation;
                }
                timeRemaining = timeRemaining1;
            }
        }
    }
}
