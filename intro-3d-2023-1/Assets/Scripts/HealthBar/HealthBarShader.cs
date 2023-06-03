using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarShader : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _healthBarRenderer;
    
    private LivingEntity _entity;

    private int _currentHealth;
    private int _totalHealth;
    private float _damagedHealthRatio = 0;
    private float _lastDamagedAt = -Mathf.Infinity;

    private void Start()
    {
        _entity = GetComponentInParent<LivingEntity>();
        if (_entity != null)
        {
            _entity.OnHealthChange += UpdateHealthBar;
            UpdateHealthBar(_entity.HealthPoints, _entity.TotalHealthPoints, 0);
        }

    }

    void UpdateHealthBar(int health, int totalHealth, int damage)
    {
        _currentHealth = health;
        _totalHealth = totalHealth;
        _damagedHealthRatio += (damage / (float) totalHealth);
        _lastDamagedAt = Time.time;
    }
    
    public void Update()
    {
        float alpha = 1f - Mathf.Max(0, Mathf.Min(0.5f, Time.time - _lastDamagedAt - 0.5f) * 2f);

        if (_damagedHealthRatio > 0) {
            _damagedHealthRatio = Mathf.Max(0, _damagedHealthRatio - Time.deltaTime * 0.4f);
        }
    }
}
