using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Data", menuName ="Bullet Datas/New")]
public class BulletScriptable : ScriptableObject
{
    public TYPE_BULLET type = TYPE_BULLET.PLAYER;
    public int damage;
    public float speed;
    
}
public enum TYPE_BULLET
{
    PLAYER,
    ENEMY
}
