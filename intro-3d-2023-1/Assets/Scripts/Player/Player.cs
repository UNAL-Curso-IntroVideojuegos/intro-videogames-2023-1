using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingEntity
{
    void Start()
    {
        InitHealth();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        //TODO: Trigger Death animation
        gameObject.SetActive(false);
    }
}
