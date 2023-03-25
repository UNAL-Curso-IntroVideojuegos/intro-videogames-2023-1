using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShoots = 1.5f;
    [SerializeField] private float _attackDelay = 0.11f;
    [SerializeField] private string _animationTrigger = "Attack1";
    
    public Action<string> OnAnimationAction;

    protected Vector3 _mouseWorldPosition;
    
    private float _nextAttackTimer = 0.0f;
    private float _attackDelayTimer = 0.0f;

    protected abstract void Attack();

    public void SetMouseWorldPosition(Vector3 mouseWorldPosition) => _mouseWorldPosition = mouseWorldPosition;
    
    private void Update()
    {
        if (_nextAttackTimer > 0)
        {
            _nextAttackTimer -= Time.deltaTime;
        }

        if (_attackDelayTimer > 0)
        {
            _attackDelayTimer -= Time.deltaTime;
            if (_attackDelayTimer <= 0)
                Attack();
        }
    }
    
    public virtual void OnTriggerHold()
    {
        if(_nextAttackTimer > 0)
            return;
      
        _nextAttackTimer = _timeBetweenShoots;
        if(_attackDelay > 0)
            _attackDelayTimer = _attackDelay;
        else
            Attack();
            
        OnAnimationAction?.Invoke(_animationTrigger);
    }

    public virtual void OnTriggerRelease(){ }
    
}
