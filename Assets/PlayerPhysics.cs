using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba") && transform.DotTest(collision.transform, Vector2.down))
        {
            collision.transform.GetComponent<EnemyController>().ShowDeathAnim();
        }
    }
}
