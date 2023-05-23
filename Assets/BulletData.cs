using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    private float damage;
    public float speed;

    public bool isDone = false;
    private Vector2 direction;
    public void Setup(float _damage, Vector2 dir)
    {
        damage = speed;
        direction = dir;
        isDone = true;
    }
    private void Update()
    {
        if (!isDone) return;
        transform.position
        += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }
}
