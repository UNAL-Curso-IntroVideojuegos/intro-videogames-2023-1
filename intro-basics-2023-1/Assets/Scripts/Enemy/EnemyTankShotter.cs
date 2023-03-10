using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShotter : MonoBehaviour, IDamageable
{
    [field: SerializeField]
    public int TotalHealthPoints { get; private set; }
    public int HealthPoints { get; private set; }

    [SerializeField] private Transform[] _barrels;
    [SerializeField] private Transform _lookAt;
    [SerializeField] private Transform[] _shootPoints;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootTimer;


    private void OnEnable()
    {
        HealthPoints = TotalHealthPoints;
        StartCoroutine(DispararCorrutine());
    }
    void Update()
    {
        CalcularAnguloDeDisparo();
    }

    public void CalcularAnguloDeDisparo()
    {
        foreach (var barrel in _barrels)
        {
            Vector3 aimVector = (_lookAt.position - barrel.position).normalized;
            float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90;

            barrel.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Disparar()
    {
        Debug.Log("Disparar enemigo");
        foreach (var shotPoint in _shootPoints)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = shotPoint.position;
            bullet.transform.rotation = shotPoint.rotation;
        }
    }

    public void TakeHit()
    {
        Debug.Log("Enemigoo");
        if (HealthPoints <= 0)
            return;

        HealthPoints--;
        if (HealthPoints <= 0)
            gameObject.SetActive(false);
    }

    IEnumerator DispararCorrutine()
    {
        yield return new WaitForSeconds(_shootTimer);
        Disparar();
        StartCoroutine(DispararCorrutine());
    }
}
