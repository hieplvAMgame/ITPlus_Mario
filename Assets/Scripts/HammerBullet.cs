using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBullet : MonoBehaviour
{
    public float force = 500.0f;
    public float gravityScale = 0.0f;
    private float _damage;

    private Vector2 _direction;
    public Rigidbody2D rb;


    private void OnEnable()
    {
        rb.gravityScale = gravityScale;
        _direction.Normalize();
        rb.AddForce(_direction * force);
    }
    public void Setup(Vector2 dir, float damage)
    {
        _direction = dir;
        _damage = damage;
    }
    void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        Vector2 velocity = rb.velocity;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
            // Spawn explosion fx
            GameObject vfx = ObjectPooling.Instance.GetObjectFromPool("Explosion");
            vfx.transform.position = transform.position;
            vfx.SetActive(true);
            ResetBullet();
        }
    }
    private void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
}
