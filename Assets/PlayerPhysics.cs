using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            if (Mathf.Abs(Vector2.Angle(contactPoint - GetComponent<Rigidbody2D>().position, Vector2.down)) < 25f)
                collision.transform.GetComponent<EnemyController>().ShowDeathAnim();
        }
    }
}
