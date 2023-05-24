using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    public float force = 500.0f; 
    public float gravityScale = 0.0f; 
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        Vector2 direction = new Vector2(1, 1);
        direction.Normalize();

        rb.AddForce(direction * force);
    }
    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
