using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [Header("Animator")]
    [SerializeField] private Transform _body;
    [SerializeField] private Transform _weaponHold;
    [SerializeField] private Transform _shootSpawnPoint;

    [Header("Weapons")]
    [SerializeField] private Weapon[] allWeapons;
    private Weapon equippedWeapon;
    
    private PlayerInput _input;
    private Animator _animator;
    
    private bool _hasAnimator;
    //private int _animAttack;
    
    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _hasAnimator = _body.TryGetComponent(out _animator);
        
        //_animAttack = Animator.StringToHash("Attack");
        
        EquippedGun(allWeapons[0]);
    }
    
    void Update()
    {
        if(equippedWeapon)
            equippedWeapon.SetMouseWorldPosition(_input.MouseWorldPosition);
        
        if (_input.TriggerHold)
            OnTriggerHold();
        
        if (_input.TriggerRelease)
            OnTriggerRelease();
    }
    
    public void EquippedGun(Weapon gunToEquip)
    {
        
        if (equippedWeapon)
        {
            equippedWeapon.OnAnimationAction -= OnWeaponAnimationAction;
            equippedWeapon.gameObject.SetActive(false);
        }

        equippedWeapon = gunToEquip;
        equippedWeapon.gameObject.SetActive(true);
        equippedWeapon.OnAnimationAction += OnWeaponAnimationAction;
        
        if(equippedWeapon is WeaponBasicProjectile)
            (equippedWeapon as WeaponBasicProjectile).SetProjectileSpawnPoint(_shootSpawnPoint);
    }
    
    private void OnTriggerHold()
    {
        if (equippedWeapon != null)
            equippedWeapon.OnTriggerHold();
    }

    private  void OnTriggerRelease()
    {
        if (equippedWeapon != null)
            equippedWeapon.OnTriggerRelease();
    }

    private void OnWeaponAnimationAction(string animationKey)
    {
        if(_hasAnimator && !string.IsNullOrEmpty(animationKey))
            _animator.SetTrigger(animationKey);
    }
}
