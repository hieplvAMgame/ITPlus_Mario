using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : CharacterData
{
    public override void GetDamage(int amount, Action<bool> isDie)
    {
        base.GetDamage(amount, isDie);
    }
}
