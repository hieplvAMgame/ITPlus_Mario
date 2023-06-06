using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData: MonoBehaviour
{
    public STATE state = STATE.ALIVE;
    public int hp;
    public int damage;

    public virtual void GetDamage(int amount, System.Action<bool> isDie)
    {
        hp -= amount;
        if (hp <= 0)
        {
            hp = 0;
            state = STATE.DEATH;
            isDie?.Invoke(true);
        }
        else
            isDie?.Invoke(false);

    }
    public void Attack(CharacterData target)
    {
        target.GetDamage(damage, (isDie) => { });
    }
}
public enum STATE
{
    ALIVE,
    DEATH
}

