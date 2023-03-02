using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankShotter : MonoBehaviour
{
    [SerializeField] private Transform[] _barrels;
    [SerializeField] private Transform _lookAt;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _shootTimer;

    private void Start()
    {

    }

    private void OnEnable()
    {
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
        foreach (var barrel in _barrels)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = barrel.position;
            bullet.transform.rotation = barrel.rotation;
        }
    }

    IEnumerator DispararCorrutine()
    {
        yield return new WaitForSeconds(_shootTimer);
        Disparar();
        StartCoroutine(DispararCorrutine());
    }
}
