using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class WeaponScriptable : ScriptableObject
{
    public string name;
    public string description = "This is an amazing weapon!!!!!";
    public int baseDamage;
    public int maxDamage;
    public int baseHp;
    public int maxHp;
    public float baseJumpForce;
    public float maxJumpForce;
    public float baseSpeed;
    public float maxSpeed;
    public Sprite preview;
    public int price = 200;

    [Header("Level Multipler value")]
    public int mulDame = 2;
    public int mulHP = 1;
    public int mulSpeed = 2;
    public int mulJump = 2;
}
