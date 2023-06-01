using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    public override void Setup(int _damage, Vector2 dir)
    {
        base.Setup(_damage, dir);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            ResetBullet();
        }
    }
}
