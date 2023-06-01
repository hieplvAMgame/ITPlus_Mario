using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float speed;

    protected virtual void Movement()
    {
    }
    public virtual void Setup(int _damage, Vector2 dir)
    {
        damage = _damage;
    }
    public virtual void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
}
