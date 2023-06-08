using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public int damage;
    [HideInInspector] public float speed;
    public BulletScriptable datas = default;
    protected virtual void Movement()
    {
    }
    public virtual void Setup(int _damage, Vector2 dir)
    {
        damage = _damage;
        damage = datas.damage;
        speed = datas.speed;
    }
    public virtual void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
}
