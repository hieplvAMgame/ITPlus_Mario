using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;

    public float speed;
    public float minX, maxX;
    private bool isTurning = false;
    private void Awake()
    {
    }
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right * speed, .75f, LayerMask.GetMask("Obstacles"));
        if (hit.collider != null)
            speed = -speed;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position+ new Vector2(.75f*speed/Mathf.Abs(speed),0));
    }
    private void FixedUpdate()
    {
        Vector2 pos = rb.position;
        if (pos.x == maxX || pos.x == minX) speed = -speed;
        pos.x += speed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.MovePosition(pos);
    }


}
