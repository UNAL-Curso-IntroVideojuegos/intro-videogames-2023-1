using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private Transform _healthMask;
    [SerializeField] private float _timeToHide = 1; 

    private LivingEntity _entity;
    private float _hideTimer;
    
    private void Start()
    {
        _entity = GetComponentInParent<LivingEntity>();
        if (_entity != null)
            _entity.OnHealthChange += UpdateHealthBar;
        
        _container.SetActive(false);
    }

    private void OnDestroy()
    {
        if (_entity != null)
            _entity.OnHealthChange -= UpdateHealthBar;
    }


    private void Update()
    {
        if(_hideTimer <= 0)
            return;

        _hideTimer -= Time.deltaTime;
        if(_hideTimer <= 0)
            _container.SetActive(false);
    }

    private void UpdateHealthBar(int health, int totalHealth, int damage)
    {
        Vector3 scale = _healthMask.localScale;
        scale.x = health / (float) totalHealth;
        _healthMask.localScale = scale;
        
        _container.SetActive(health > 0);
        _hideTimer = _timeToHide;
    }
}
