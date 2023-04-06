using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public static explicit operator Player(Transform v)
    {
        throw new NotImplementedException();
    }
}
