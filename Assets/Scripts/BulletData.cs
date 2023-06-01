using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : Bullet
{
    public bool isDone = false;
    private Vector2 direction;
    public override void Setup(int _damage, Vector2 dir)
    {
        base.Setup(_damage,dir);
        direction = dir;
        isDone = true;
    }
    private void Update()
    {
        Movement();
    }
    protected override void Movement()
    {
        base.Movement();
        if (!isDone) return;
        transform.position
        += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        if (direction.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = Vector3.up * 180;
        }
    }
}
