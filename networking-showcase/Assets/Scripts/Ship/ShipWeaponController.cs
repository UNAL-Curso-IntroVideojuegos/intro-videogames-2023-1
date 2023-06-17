using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipNetwork.Gameplay
{
    public class ShipWeaponController : MonoBehaviour
    {
        public Transform weaponHold;
        [SerializeField] Weapon equippedWeapon;
        

        public void EquipGun(Weapon weaponToEquip)
        {
            if (equippedWeapon != null)
                Destroy(equippedWeapon.gameObject);
            equippedWeapon = Instantiate(weaponToEquip, weaponHold.position, weaponHold.rotation);
            equippedWeapon.transform.parent = weaponHold;
            equippedWeapon.SetShipOwner(this);
        }
        
        public void OnTriggerHold()
        {
            if (equippedWeapon != null)
                equippedWeapon.OnTriggerHold();
        }

        public void OnTriggerRelease()
        {
            if (equippedWeapon != null)
                equippedWeapon.OnTriggerRelease();
        }
        
        public void Aim(Vector3 aimPoint)
        {
            if (equippedWeapon != null)
                equippedWeapon.Aim(aimPoint);
        }
    }
}